using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6_Task2
{
    class BookList
    {
        //ПОЛЯ
        private Book[] array;//массив книг
        int size;//размер массива

        //СВОЙСТВА
        private int Index { get; set; }//последний индекс доступный для записи
        public int Size
        {
            get => size;
            set
            {
                //"уменьшение" списка не поддерживается
                try
                {
                    if (size != 0 && value < array.Length)
                        throw new NotSupportedException("The operation is not supported. The size of the array must be larger than the current one!");

                    //был нулевой размер
                    //создаем массив указанного размера
                    //без копирования!!!
                    if (size == 0 && value != 0)
                    {
                        array = new Book[value];
                        size = value;
                        return;
                    }

                    //если новый размер не 0, и больше старого
                    //создаем новый массив и копируем в него книги
                    if (value != 0 && value > array.Length)
                    {
                        Book[] temp = new Book[value];
                        int ind = 0;//индекс для записи в новый массив

                        foreach (Book el in array)
                        {
                            temp[ind++] = el;
                        }

                        array = temp;//меняем массив
                        Index = ind;//обновляем индекс
                        size = value;//меняем размер
                    }
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine($"An exception ({ex.GetType().Name}) occurred. {ex.Message} ");
                }
            }
        }
        

        //КОНСТРУКТОРЫ
        public BookList(int size = 0)//размер по умолчанию 0
        {
            Size = size;
            array = new Book[Size];
            Index = 0;//индекс для записи 0
        }

        //ИНДЕКСАТОРЫ
        public Book this[int index]
        {
            get
            {
                try
                {
                    //выход за границы массива
                    if (index >= Index)
                        throw new IndexOutOfRangeException("The index is out of range!");
                    return array[index];//иначе вернем книгу
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"An exception ({ex.GetType().Name}) occurred. {ex.Message} ");
                    return null;
                }  
            }       
            set
            {
                try
                {
                    //выход за границы массива
                    if (index >= Index)
                        throw new IndexOutOfRangeException("The index is out of range!");
                    array[index] = value;//иначе установим значение по индексу
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"An exception ({ex.GetType().Name}) occurred. {ex.Message} ");
                }
            }
        }
            
        //ОПЕРАТОРЫ
        public static BookList operator+(BookList list, Book book)//добавить книгу
        {
            //если место в массиве закончилось
            if (list.Index >= list.Size)
            {
                ++list.Size;//увеличиваем массив на 1
                Book[] temp = new Book[list.Size];//создаем временный массив книг

                //копируем в него все книги из старого массива
                for (int i = 0; i < list.Size - 1; ++i)
                {
                    temp[i] = list[i];
                }

                temp[list.Index++] = book;//в конец добавляем новую книгу и инк индекс
                list.array = temp;//меняем массив на новый
            }
            //если в массиве есть свободное место
            else
                list[list.Index++] = book;//в конец добавляем новую книгу и инк индекс

            return list;
        }
        
        public static BookList operator -(BookList list, Book book)//удалить книгу из списка
        {
            //если книга в списке существует
            if (list.IsExist(book))
            {
                //создадим новый массив на 1 меньше старого
                Book[] temp = new Book[list.Size - 1];
                int ind = 0;//индекс для записи в новый массив

                //копируем в новый массив все книги, кроме той, которую требуется удалить
                for (int i = 0; i < list.Size; ++i)
                {
                    if (list.array[i] != book)
                        temp[ind++] = list[i];
                }
                list.array = temp;//меняем массив
                list.Index = ind;//меняем индекс для записи
            }

            return list;
        }
        public static BookList operator -(BookList list, string book_name)//удалить книгу по названию
        {
            //если внига существует
            if (list.IsExist(book_name))
            {
                //создадим новый массив на 1 меньше старого
                Book[] temp = new Book[list.Size - 1];
                int ind = 0;//индекс для записи в новый массив

                //копируем в новый массив все книги, кроме той, которую требуется удалить
                for (int i = 0; i < list.Size; ++i)
                {
                    if (list.array[i].Name != book_name)
                        temp[ind++] = list[i];
                }

                list.array = temp;//меняем массив
                list.Index = ind;//меняем индекс для записи
            }

            return list;
        }

        //МЕТОДЫ
        public bool IsExist(Book book)//существует ли книга в списке
        {
            foreach (Book el in array)
            {
                if (el == book) //найдена
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsExist(string book_name)//существует ли книга в списке по названию
        {
            foreach (Book el in array)
            {
                if (el.Name == book_name)//найдена
                {
                    return true;
                }
            }
            return false;
        }

        public void Print()//печать списка книг
        {
            Console.WriteLine();
            foreach(Book el in array)
            {
                el.Print();
            }
        }
        
        //вложенный класс Книга
        public class Book
        {
            //СВОЙСТВА
            public string Name { get; set; }
            public string Author { get; set; }

            //КОНСТРУКТОР
            public Book(string name, string author)
            {
                Name = name;
                Author = author;   
            }

            //ОПЕРАТОРЫ
            public static bool operator==(Book obj1, Book obj2)//для сравнения книг
            {
                return (obj1.Name == obj2.Name && obj1.Author == obj2.Author);
            }
            public static bool operator !=(Book obj1, Book obj2)//"---"---"
            {
                return !(obj1.Name == obj2.Name && obj1.Author == obj2.Author);
            }


            //МЕТОДЫ
            public void Print()//печать отдельной книги
            {
                Console.WriteLine($"{Author,20} {Name,30}");
            }
        }
        
    }
}
