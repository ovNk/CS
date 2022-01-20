/*
Прочитать массив строк с клавиатуры.
Перечислить их длины. Вывести на экран
первую и последнюю буквы самой длинной строки.
*/
using System;

namespace Lesson3_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();//датчик случайных чисел
            string[] str = new string[rand.Next(3, 11)];//случайный размер(3-10)
            int max_len = 0;//определим длины строк и найдем максимальную
            int max_len_ind = 0;//индекс строки с максимальной длиной

            for (int i = 0; i < str.Length; ++i) 
            {
                Console.WriteLine($"Enter string N{i + 1}: ");
                str[i] = Console.ReadLine();//приглашение ко вводу
                Console.WriteLine(str[i].Length);//читаем строку

                if (max_len < str[i].Length)//поиск максимальной длины строки в массиве
                {
                    max_len = str[i].Length;
                    max_len_ind = i;
                }
            }

            Console.WriteLine($"Longest string: {str[max_len_ind]}.\n" +
                $"First letter: {str[max_len_ind][0]}.\nLast letter: {str[max_len_ind][str[max_len_ind].Length - 1]}.");

            return;
        }
    }
}
