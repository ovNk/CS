/*Пользователь вводит словами цифру от 0 до 9. 
Приложение должно перевести слово в цифру. Например, если
пользователь ввёл five, приложение должно вывести на
экран 5.*/
using System;

namespace Lesson5_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            AssociativeArray ob = new AssociativeArray();
            ob.AddElem(1, "one");
            ob.AddElem(2, "two");
            ob.AddElem(3, "three");
            ob.AddElem(4, "four");
            ob.AddElem(5, "five");
            ob.AddElem(6, "six");
            ob.AddElem(7, "seven");
            ob.AddElem(8, "eight");
            ob.AddElem(9, "nine");
            ob.AddElem(0, "zero");

            ob.Print();
            ob.AddElem(10,"ten");
            ob.Print();
            ob.Size = 12;
            //int d = ob["three"];
            //Console.WriteLine(Convert.ToString(ob["SIX"]));

        }
    }
}
