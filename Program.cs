using System;
using System.Collections.Generic;

namespace Lesson12
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Создайте пустой динамический массив строк. 
             * Программа в цикле предлагает пользователю
             * добавлять по одной строке. Так продолжается,
             * пока пользователь не нажмёт Enter (введёт пустую строку).
             * Распечатайте получившийся список.*/
            List<string> lines = new List<string>();

            Console.WriteLine("Enter a strings:");
            string current = Console.ReadLine();
            while (current != "")
            {
                lines.Add(current);
                current = Console.ReadLine();
            }

            Console.WriteLine("Lines:");
            foreach (string el in lines)
            {
                Console.WriteLine(el);
            }

            /*Создайте пустой динамический массив геометрических фигур.
             * Фигуры бывают квадратами, кругами, треугольниками. Программа
             * в цикле предлагает пользователю добавить ещё одну фигуру 
             * в массив. Для этого она показывает текстовое меню. 
             * Цикл прерывается, когда пользователь выбирает специальный пункт меню «Конец».
             * Распечатайте накопившиеся фигуры.*/

            //пустой динамический массив фигур
            List<IFigure> shapes = new List<IFigure>();
         
            //массив фигур для выбора в меню по индексу
            IFigure[] shape_arr = new IFigure[3]
            {
                new Square(),
                new Triangle(),
                new Sphere()
            };

            //показываем меню и чистаем первый ответ
            Console.WriteLine("0.Exit\n1.Square\n2.Triangle\n3.Sphere");
            int answer = Int32.Parse(Console.ReadLine());

            //пока не выбран выход
            while (answer != 0)
            {
                //добавляем в массив соответствующую фигуру по индексу
                shapes.Add(shape_arr[answer - 1]);
                //следующий ответ
                answer = Int32.Parse(Console.ReadLine());
            }
            
            //Печать фигур в массиве
            Console.WriteLine("Shapes:");
            foreach (IFigure el in shapes)
            {
                Console.WriteLine(el);
            }
        }
    }
}
