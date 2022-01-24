/*Объявить одномерный (5 элементов) массив с име-
нем A и двумерный массив (3 строки, 4 столбца) дроб-
ных чисел с именем B. Заполнить одномерный массив
А числами, введенными с клавиатуры пользователем, а
двумерный массив В случайными числами с помощью
циклов. Вывести на экран значения массивов: массива
А в одну строку, массива В — в виде матрицы. Найти в
данных массивах общий максимальный элемент, мини-
мальный элемент, общую сумму всех элементов, общее
произведение всех элементов, сумму четных элементов
массива А, сумму нечетных столбцов массива В.*/
using System;

namespace Lesson4_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            double[] A = new double[5];
            double[,] B = new double[3, 4];
            
            double max = -1;//переменные
            double min = 100;//для поиска общих макс и мин элементов

            double sum_even_a = 0;//сумма четных элементов в массиве А
            double sum_odd_b = 0;//и нечетных столбцов массива В

            Console.WriteLine("A: ");
            for (int i = 0; i < A.Length; ++i)
            {
                //A[i] = Convert.ToDouble(Console.ReadLine());//запрос у пользователя
                A[i] = rand.NextDouble() + rand.Next(1, 100);//рандом 1.1 до 99.9
                if (i % 2 == 0)//считаем сумму четных элементов
                    sum_even_a += A[i];
            }

            for (int i = 0; i < B.GetLength(0); ++i) 
            {
                for (int j = 0; j < B.GetLength(1); ++j)
                {
                    B[i, j] = rand.NextDouble() + rand.Next(1, 100);//рандом 1.1 до 99.9
                    if (j % 2 != 0)//считаем сумму нечетных столбцов
                        sum_odd_b += B[i, j];
                }
            }

            Console.WriteLine("Array A:");//вывод массива А в строку
            for (int i = 0; i < A.Length; ++i)
            {
                Console.Write($"{A[i], 5:F1} ");
            }
            Console.WriteLine("\n\nArray B:");//вывод массива В в виде матрицы
            for (int i = 0; i < B.GetLength(0); ++i)
            {
                for (int j = 0; j < B.GetLength(1); ++j)
                {
                    Console.Write($"{B[i, j], 5:F1} ");
                }
                Console.WriteLine();
            }

            //поиск общих макс и мин
            //проход по массиву А
            for (int i = 0; i < A.Length; ++i)
            {
                if (If_exist(B, A[i]))//если элемент существует в массиве В
                {
                    if (max < A[i]) //ищем макс
                        max = A[i];
                    if (min > A[i]) // и мин
                        min = A[i];
                }
            }

            if (max == -1 || min == 100)//переменные имеют стартовые значения, общих элементов нет
                Console.WriteLine("\nThere are no common elements in the arrays!\n");
            else
                Console.WriteLine($"\nMax = {max:F1}\nMin = {min:F1}\n");//вывод если есть
            //Сумма элементов в массивах
            Console.WriteLine($"The sum of the elements in the array A: {Sum_elem(A):F1}\n" +
                $"The sum of the elements in the array B: {Sum_elem(B):F1}\n");
            //Произведение элементов в массивах
            Console.WriteLine($"The product of the elements in the array A: {Product_elem(A):F1}\n" +
                $"The product of the elements in the array B: {Product_elem(B):F1}\n");
            //сумма четных элементов в массиве А
            //и нечетных столбцов в массиве В
            Console.WriteLine($"The sum of even array elements A: {sum_even_a:F1}\n" +
                $"The sum of the odd columns of the array B: {sum_odd_b:F1}\n");
            
            return;
        }

        static bool If_exist(double[,] B, double num)//проверяет, существует ли элемент в массиве B
        {
            foreach(double i in B)
            {
                if ( num >= i && (num - i) < 0.1)//сравнение до 2 знака после запятой
                    return true;//элемент найден
            }
            return false;//элемента в массиве В не существует
        }

        static double Sum_elem(double[] arr)//подсчет суммы одномерного массива
        {
            double sum = 0;
            foreach (double i in arr) 
            {
                sum += i;
            }

            return sum;
        }
        static double Sum_elem(double[,] arr)//перегрузка для двумерного
        {
            double sum = 0;
            foreach (double i in arr)
            {
                sum += i;
            }

            return sum;
        }

        static double Product_elem(double[] arr)//подсчет произведения элементов одномерного массива
        {
            double prod = 1;
            foreach (double i in arr)
            {
                prod *= i;
            }

            return prod;
        }

        static double Product_elem(double[,] arr)//перегрузка для двумерного
        {
            double prod = 1;
            foreach (double i in arr)
            {
                prod *= i;
            }

            return prod;
        }

    }
}
