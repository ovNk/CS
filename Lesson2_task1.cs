/*
Ввести с клавиатуры три названия городов.
Вывести на печать их через запятую, в конце поставить точку.
 */
using System;

namespace Lesson2_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string city_1;
            string city_2;
            string city_3;

            //Ввод городов
            Console.WriteLine("City N1: ");
            city_1 = Console.ReadLine();
            Console.WriteLine("City N2: ");
            city_2 = Console.ReadLine();
            Console.WriteLine("City N3: ");
            city_3 = Console.ReadLine();

            //Вывод через , с . на конце
            Console.WriteLine($"{city_1}, {city_2}, {city_3}.");

            return;

        }
    }
}
