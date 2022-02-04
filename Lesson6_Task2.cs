/*Создайте приложение «Список книг для прочтения».
Приложение должно позволять добавлять книги в список, 
удалять книги из списка, проверять есть ли книга в
списке, и т. д. Используйте механизм свойств, перегрузки
операторов, индексаторов.*/
using System;


namespace Lesson6_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //создадим список
            BookList list = new BookList();

            //добавим книги
            list += new BookList.Book("Harry Potter", "J.K.Rowling");
            list += new BookList.Book("The Lord of the Rings","J.R.R.Tolkien");
            list += new BookList.Book("Hercule Poirot", "Agatha Christie");
            list += new BookList.Book("Harry Potter", "Erle Stanley Gardner");
            list += new BookList.Book("Nero Wolfe", "Rex Stout");

            //печать списка книг
            list.Print();

            //если книга существует - удалим ее из списка
            if (list.IsExist("Hercule Poirot")) 
                list -= "Hercule Poirot";
            
            //печать списка книг
            list.Print();

            //индексаторы
            list[3].Print();
            list[3]=new BookList.Book("Hercule Poirot", "Agatha Christie");
            list.Print();
        }
    }
}
