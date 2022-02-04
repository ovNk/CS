using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6_Task1
{
    class Matrix
    {
        //ПОЛЯ
        int[,] matrix;
        int row;
        int column;

        //СВОЙСТВА
        public int Row
        {
            get => row;
            private set => row = value > 0 ? value : 1;//по умолчанию построить матрицу 1х1
        }
        public int Column
        {
            get => column;
            private set => column = value > 0 ? value : 1;//по умолчанию построить матрицу 1х1
        }

        //КОНСТРУКТОРЫ
        public Matrix(int row, int column)//построить через rows/columns
        {
            Row = row;
            Column = column;
            matrix = new int[Row, Column];
        }
        public Matrix(int[,] arr)//передать готовый массив
        {
            Row = arr.GetLength(0);
            Column = arr.GetLength(1);
            matrix = arr;
        }

        //ИНДЕКСАТОРЫ
        public int this[int i,int j]
        {
            get => matrix[i, j];//вернуть значение по индексам
            set => matrix[i, j] = value;//установить значение по индексам
        }

        //ОПЕРАТОРЫ
        public static Matrix operator +(Matrix obj1, Matrix obj2)//сложение матриц
        {
            //матрицы должны быть одинакового размера
            if (obj1.Row != obj2.Row || obj1.Column != obj1.Column)
                return null;

            Matrix result = new Matrix(obj1.Row, obj2.Column);

            //складываем поэлементно
            for (int i = 0; i < result.Row; ++i)
            {
                for (int j = 0; j < result.Column; ++j)
                {
                    result[i, j] = obj1[i, j] + obj2[i, j];
                }
            }

            return result;
        }
        public static Matrix operator -(Matrix obj1, Matrix obj2)//вычитание матриц
        {
            //матрицы должны быть одинакового размера
            if (obj1.Row != obj2.Row || obj1.Column != obj2.Column)
                return null;

            Matrix result = new Matrix(obj1.Row, obj1.Column);

            //вычитаем поэлементно
            for (int i = 0; i < result.Row; ++i)
            {
                for (int j = 0; j < result.Column; ++j)
                {
                    result[i, j] = obj1[i, j] - obj2[i, j];
                }
            }

            return result;
        }
        public static Matrix operator *(Matrix obj1, int mult)//умножение матрицы на число
        {
            
            Matrix result = new Matrix(obj1.Row, obj1.Column);

            //поэлементно умножаем
            for (int i = 0; i < result.Row; ++i)
            {
                for (int j = 0; j < result.Column; ++j)
                {
                    result[i, j] = obj1[i, j] * mult;
                }
            }

            return result;
        }
        public static Matrix operator *(Matrix obj1, Matrix obj2)//произведение матриц
        {

            if (obj1.Column != obj2.Row) //если матрицы несовместимы (столбцы А != строки В)
                return null;

            //результат
            Matrix result = new Matrix(obj1.Row, obj2.Column);

            int temp = 0;//переменная для подсчета элементов матрицы
            int t = 0;//счетчик

            for (int i = 0; i < result.Row; ++i)
            {
                for (int j = 0; j < result.Column; ++j)
                {
                    while (t < obj2.Row)//считаем элемент строки i столбца j
                    {
                        //у матрицы А изменяется столбец
                        //у В строка
                        temp += obj1[i, t] * obj2[t++, j];
                    }
                    //результат подсчитан
                    result[i, j] = temp;

                    t = 0;//сбрасываем счетчик на 0
                    temp = 0;//временную переменную на 0
                }
            }

            return result;
        }
        
        public static bool operator ==(Matrix obj1, Matrix obj2)//сравнение на равенство матриц
        {
            if (obj1.Row != obj2.Row || obj1.Column != obj2.Column)//размеры не совпали
                return false;

            for (int i = 0; i < obj1.Row; ++i)
            {
                for (int j = 0; j < obj2.Column; ++j)
                {
                    if (obj1[i, j] != obj2[i, j])//найдено несоответствие
                        return false;
                }
            }

            return true;//матрицы равны
        }

        public static bool operator !=(Matrix obj1, Matrix obj2)//сравнение на неравенство
        {
            return !(obj1 == obj2);
        }

        //МЕТОДЫ
        public void InitRandom()//инициализация случайными 0-99
        {
            Random rand = new Random();
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = rand.Next(0, 100);
                }
            }
        }
        public void Init()//читаем с клавиатуры
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public void Print()//печать матрицы
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write($"{matrix[i, j], 5} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            return;
        }

    }
}
//TODO
//EQUALS??
//hash???
//comments
