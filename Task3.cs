/*Даны целые положительные числа A и B (A < B).
Вывести все целые числа от A до B включительно;
каждое число должно выводиться на новой строке; 
при этом каждое число должно выводиться количество раз,
равное его значению (например, число 3 выводится 3 раза). 
Например: если А = 3, а В = 7, то программа
должна сформировать в консоли следующий вывод:
3 3 3
4 4 4 4
5 5 5 5 5
6 6 6 6 6 6
7 7 7 7 7 7 7 */
using System;

namespace Lesson1_task3
{
    class Program
    {
        static void Main(string[] args)
        {
            uint a = 0;//начальная инициализация 0
            uint b = 0;//начальная инициализация 0

            Check(ref a, ref b);//Ввод данных и проверка на удовлетворение условиям

            //цикл для вывода результата
            for (uint i = a; i <= b; ++i) 
            {
                for (uint j = 0; j < i; ++j) 
                {
                    Console.Write(i + " ");
                }
                Console.Write("\n");
            }

            return;
        }

        static void Check(ref uint a, ref uint b)//функция проверки вводимых значений
        {
            Console.WriteLine("Enter A: ");
            a = Convert.ToUInt32(Console.ReadLine());
            //пока а неположительно
            while (a <= 0)
            {
                Console.WriteLine("Incorrect!\nA must be greater than 0!\nEnter A: ");
                a = Convert.ToUInt32(Console.ReadLine());
            }

            Console.WriteLine("Enter B: ");
            b = Convert.ToUInt32(Console.ReadLine());
            //пока в неположительно
            while (a <= 0)
            {
                Console.WriteLine("Incorrect!\nB must be greater than 0!\nEnter B: ");
                b = Convert.ToUInt32(Console.ReadLine());
            }

            //пока не соответствуют условию А < B
            while (a >= b)
            {
                Console.WriteLine("Incorrect!\nA must be less than B!");
                Check(ref a, ref b);
            }    
                
            return;
        }
    }
}
