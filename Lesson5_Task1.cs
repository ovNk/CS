/*Создайте приложение калькулятор для перевода числа
из одной системы исчисления в другую. Пользователь с 
помощью меню выбирает направление перевода. Например,
из десятичной в двоичную. После выбора направления,
пользователь вводит число в исходной системе исчисления.
Приложение должно перевести число в требуемую систему. 
Предусмотреть случай выхода за границы диапазона,
определяемого типом int, неправильный ввод.*/
using System;
using System.Collections.Generic;

namespace Lesson5_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver();

            return;
        }

        static string Translator(int from, int to, string number)//перевод числа
        {
            string result;//строка для результата

            //если перевод не из 10 системы
            //сначала переведем в десятичную
            if (from != 10)
            {
                number = ToTen(number, from);
            }
            result = FromTen(Convert.ToInt32(number), to);//потом в требуемую

            return result;
        }
       
        static string ToTen(string number, int from)//перевод в десятичную сс
        {
            int pow = number.Length - 1;//показатель степени для возведения основания при расчетах
            string alpha = "0123456789ABCDEF";//алфавит
            double result = 0;//переменная для подсчета результата
                
            for (int i = 0; i < number.Length; ++i)//подсчет результата
            {
                result += Convert.ToDouble(alpha.IndexOf(number[i])) * Math.Pow(from, pow--);
            }

            string str = Convert.ToString(result);//строка представляет результат

            return str;//возврат результата
        }

        static string FromTen(int number, int to)//перевод из десятичной сс
        {
            string result = "";//строка для результата
            string alpha = "0123456789ABCDEF";//алфавит

            while (number > 0)//пока больше 0
            {
                result += alpha[number % to];//считаем остатки от деления
                number /= to;
            }

            result = Revers(result);//переворачиваем строку

            return result;
        }

        static string Revers(string str)//переворот строки
        {
            char[] buf = new char[str.Length];//временный массив для результата
            int i = str.Length - 1;//счетчик от конца входной строки
            int j = 0;//счетчик от начала массива

            //переворот строки
            while (i >= 0) 
            {
                buf[j++] = str[i--];
            }

            string result = new string(buf);//строка для результата

            return result;
        }

        static void Driver()//драйвер
        {
            string acceptable = "2 8 10 16";//допустимые системы счисления
            string number;//строка для числа
            int from;//из какой сс выполняется перевод
            int to;//в какую сс выполняется перевод

            Console.WriteLine("From: ");
            from = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("To: ");
            to = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number: ");
            number = Console.ReadLine();

            try
            {
                //некорректный ввод
                if (!acceptable.Contains(Convert.ToString(from)) || !acceptable.Contains(Convert.ToString(to)))
                {
                    throw new ArgumentException("Error!\nThe number system: 2 8 10 16!");
                }

                //печать переведенного числа
                Console.WriteLine(Translator(from, to, number));
                             
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
            
        }
    }
}
