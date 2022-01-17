/*
Написать программу, которая считывает символы
с клавиатуры, пока не будет введена точка.
Программа должна сосчитать количество введенных
пользователем пробелов.
*/
using System;

namespace Lesson2_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch;//символ
            int space = 0;//переменная для подсчета количества пробелов

            Console.WriteLine("Characters: ");
            ch = (char)Console.Read();//читаем первый символ

            while (ch != 46) //пока не введена .
            {
                if (ch == 32)//если введен пробел
                    ++space;
                ch = (char)Console.Read();//читаем следующий символ
            }

            Console.WriteLine($"Spaces: {space}.");//выводим количество пробелов

            return;
        }
    }
}
