/*
Заполнить массив случайными числами.
Найти сумму элементов массива.
Может ли при сложении потребоваться checked?
---Ну, вообще, зависит наверное от типа данных, размера массива и диапазона случайных чисел:DD
Вдруг мы решим заполнить массив инт значениями, близкими к 2ккк:DD
*/
using System;

namespace Lesson3_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();//датчик случайных чисел
            int summ = 0;//сумма элементов
            int[] arr = new int[rand.Next(10, 31)];//случайный размер 10-30

            Console.WriteLine("Array:");
            for (int i = 0; i < arr.Length; ++i) 
            {
                arr[i] = rand.Next(1, 100);//случайные от 1 до 99
                summ += arr[i];//считаем сумму
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine($"\nSumm = {summ}");

            return;
        }
    }
}
