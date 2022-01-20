/*
Создать массив. Пройти по нему циклом.
Для каждого числа создать строку из этих цифр этой длины
*/
using System;

namespace Lesson3_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();//датчик случайных чисел
            int[] arr = new int[rand.Next(5, 16)];//массив случайного размера(5-15)
            string[] str = new string[arr.Length];//массив строк аналогичного размера

            for (int i = 0; i < arr.Length; ++i) 
            {
                arr[i] = rand.Next(1, 10);//случайное число 1-9
                Console.Write($"{arr[i]}: ");//вывод числа
                str[i] = "";//создаем пустую строку
                for (int j = 0; j < arr[i]; ++j)//и добавляем к ней цифры до нужной длины
                    str[i] += arr[i];
                Console.WriteLine(str[i]);//вывод строки
            }

            return;
        }
    }
}
