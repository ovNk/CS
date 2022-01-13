/*
Дано целое число N большее 0,
найти число, полученное при прочтении числа N справа налево. Например,
если было введено число 345, то программа должна
вывести число 543.*/
using System;

namespace Lesson1_task4
{
    class Program
    {
        static void Main(string[] args)
        {
            uint num;//число
            uint temp;//переменная для вычисления итогового числа
            uint new_num;//итоговое число


            Console.WriteLine("Enter N: ");
            num = Convert.ToUInt32(Console.ReadLine());
            //проверка на корректность ввводимых значений (N>0)
            while (num <= 0) 
            {
                Console.WriteLine("N must be greater than 0!\nEnter N: ");
                num = Convert.ToUInt32(Console.ReadLine());
            }

            temp = num;//присваиваем временой переменной значение числа N
            new_num = temp % 10;//устанавливаем первую цифру нового числа(последняя цифра числа N)
            temp /= 10;//и укорачиваем число N на 1 разряд

            while (temp > 0) 
            {
                new_num *= 10;        //считаем
                new_num += temp % 10;//следующий разряд нового числа
                temp /= 10;//и укорачиваем число N
            }

            Console.WriteLine(new_num);//вывод итогового числа

            return;
        }
    }
}
