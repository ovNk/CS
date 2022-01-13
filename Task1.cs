/*Даны целые положительные числа A, B, C. Значение
этих чисел программа должна запрашивать у пользователя.
На прямоугольнике размера A*B размещено
максимально возможное количество квадратов со
стороной C. Квадраты не накладываются друг на
друга. 
Найти количество квадратов, размещенных на
прямоугольнике, а также площадь незанятой части
прямоугольника.
Необходимо предусмотреть служебные сообщения
в случае, если в прямоугольнике нельзя разместить ни
одного квадрата со стороной С (например, если значение С превышает размер сторон прямоугольника).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ВВод сторон прямоугольника и стороны квадрата
            Console.WriteLine("Enter A: ");
            double A = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter B: ");
            double B = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter C: ");
            double C = Convert.ToDouble(Console.ReadLine());

            //Проверка
            int i = (A >= C ? 1 : 0);//если сторона квадрата больше А
            int j = (B >= C ? 1 : 0);//если сторона квадрата больше В

            if (i == 0 || j == 0 || C <= 0) //если хоть одна сторона прямоугольника меньше C, или С неположительное значение
            {
                Console.WriteLine("Incorrect C value.\nThe given rectangle does not fit squares with side C.");
                return;//возврат
            }

            i = Convert.ToInt32(A / C);//сколько квадратов поместится по стороне А
            j = Convert.ToInt32(B / C);//и сколько по стороне В
            
            Console.WriteLine($"The given rectangle contains {i * j} squares with side {C}.\nThe free surface area is {A * B - C * C * i * j}");

            return;

        }
    }
}
