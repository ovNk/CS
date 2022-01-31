using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5_Task2
{
    class AssociativeArray
    {
        //ЭКЗЕМПЛЯРНЫЕ ПОЛЯ
        int size;//размер массивов
        int[] key;//массив с ключами. Уникальны
        string[] val;//массив со значениями
        int index = 0;//индекс для записи в массивы

        //СВОЙСТВА
        public int Size
        {
            get => size;
            set
            {
                //"уменьшение" массива не поддерживается
                try
                {
                    if (size != 0 && value < key.Length) 
                        throw new NotSupportedException("The operation is not supported. The size of the array must be larger than the current one!");

                    //был нулевой размер
                    //создаем массив указанного размера
                    //без копирования!!!
                    if (size == 0 && value != 0)
                    {
                        key = new int[value];
                        val = new string[value];
                        size = value;
                        return;
                    }

                    //если новый размер не 0, и больше старого
                    //создаем новые массивы и копируем в них значения и ключи
                    if (value != 0 && value > key.Length)
                    {
                        //копируем ключи
                        int[] temp_key = new int[value];
                        int index = 0;
                        foreach (int el in key)
                        {
                            temp_key[index++] = el;
                        }
                        key = new int[value];
                        key = temp_key;

                        //копируем значения
                        string[] temp_val = new string[value];
                        index = 0;
                        foreach (string el in val)
                        {
                            temp_val[index++] = el;
                        }
                        val = new string[value];
                        val = temp_val;

                        size = value;
                    }
                }
                catch(NotSupportedException ex)
                {
                    Console.WriteLine($"An exception ({ex.GetType().Name}) occurred. {ex.Message} ");
                }

            }
        }

        //ИНДЕКСАТОРЫ
        public string this[int key]//ищем значение по ключу
        {
            get
            {
                int index = Find(key);

                if (index != -1)
                    return val[index];

                return null;
            }
        }
        public int this[string val]//и ключ по значению
        {
            get
            {
                int index = Find(val);

                if (index != -1)
                    return key[index];

                return -1;
            }
        }

        //КОНСТРУКТОР
        public AssociativeArray(int size = 0)
        {
            this.size = size;
            if (size != 0)//если размер не 0
            {
                key = new int[size];//создаем массив ключей
                val = new string[size];//и значений
            }
        }

        //МЕТОДЫ
        private int Find(int key)//ищем ключ
        {
            int index = 0;//индекс искомого элемента
            for (int i = 0; i < this.key.Length; ++i)
            {
                if (this.key[i] == key)//элемент найден
                {
                    index = i;
                    return index;//вернем индекс
                }
            }

            //элемент не найден, возврат -1
            return -1;
        }

        private int Find(string val)//ищем строку 
        {
            int index = 0;//индекс искомого элемента
            for (int i = 0; i < this.key.Length; ++i)
            {
                if (this.val[i] == val.ToLower())//элемент найден
                {
                    index = i;
                    return index;//возврат индекс
                }
            }

            //элемент не найден, возврат -1
            return -1;
        }

        public bool AddElem(int key, string val)
        {
            if (size == 0)//нулевой размер массивов
            {
                Size = size + 1;
            }
            else if (Find(key) != -1)//элеменнайден, ключ уже существует
                return false;

            if(index == size)//если достигнут конец массива
            {
                Size = size + 1;
            }

            //иначе добавляем элемент
            this.key[index] = key;
            this.val[index] = val;

            //инк индекс
            ++index;

            return true;
        }

        public bool DeleteElem(string val)//удаляем ВСЕ элементы с найденными значениями
        {
            if (Find(val) == -1)//элемен не найден
                return false;

            int index = Find(val);//индекс первого элемента с текущим значением
            int t = 0;//для итерации по новым массивам

            while (index != -1)//пока в массиве есть значения
            {
                string[] temp_val = new string[size - 1];//создаем массивы 
                int[] temp_key = new int[size - 1];//размером на 1 меньше

                //копируем все значения, кроме элементов с найденным индексом
                for (int i = 0; i < size; ++i) 
                {
                    if (i != index) 
                    {
                        temp_val[t] = this.val[i];
                        temp_key[t++] = key[i];
                    }
                }

                this.val = temp_val;
                key = temp_key;
                size -= 1;
                --this.index;

                index = Find(val);//ищем следующий элемент
            }

            return true;

        }

        public bool DeleteElem(int key)//ключ уникален, удаляем только значение с текущим ключом
        {
            if (Find(key) == -1)//элемент не найден
                return false;

            int index = Find(key);//индекс элемента с текущим ключом
            int t = 0;//для итерации по новым массивам

            string[] temp_val = new string[size - 1];//создаем массивы 
            int[] temp_key = new int[size - 1];//размером на 1 меньше

            //копируем все значения, кроме элементов с найденным индексом
            for (int i = 0; i < size; ++i)
            {
                if (i != index)
                {
                    temp_val[t] = this.val[i];
                    temp_key[t++] = this.key[i];
                }
            }

            val = temp_val;
            this.key = temp_key;
            size -= 1;
            --this.index;

            return true;

        }

        public bool DeleteElem(int key, string val)//удаляем только пару ключ - значение
        {
            if (Find(key) == -1 || Find(val) == -1)//элемент не найден
                return false;

            int index = Find(key);//индекс найденной пары
            int t = 0;//для итерации по массивам

            string[] temp_val = new string[size - 1];//создаем массивы 
            int[] temp_key = new int[size - 1];//размером на 1 меньше

            //копируем все значения, кроме элементов с найденным индексом
            for (int i = 0; i < size; ++i)
            {
                if (i != index)
                {
                    temp_val[t] = this.val[i];
                    temp_key[t++] = this.key[i];
                }
            }

            this.val = temp_val;
            this.key = temp_key;
            size -= 1;
            --this.index;

            return true;

        }

        public void Print()
        {
            for (int i = 0; i < size; ++i) 
            {
                Console.WriteLine($"Key: { key[i]}\tVal: {val[i]}");
            }
            Console.WriteLine();
        }

        //TODO 
        //Удалить элемент ++
        //Ситуация с 0!!! +-
        //РЕГИСТР ++
        //исключения+-
    }
}
