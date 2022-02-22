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

            List<IFigure> shapes = new List<IFigure>();
            Dictionary<int, IFigure> shapeDict = new Dictionary<int, IFigure>()
            {
                { 1, new Square() },
                { 2, new Triangle() },
                { 3, new Sphere() }
            };

            Console.WriteLine("0.Exit\n1.Square\n2.Triangle\n3.Sphere");
            int answer = Int32.Parse(Console.ReadLine());

            while (answer != 0)
            {
                shapes.Add(shapeDict[answer]);
                answer = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Shapes:");
            foreach (IFigure el in shapes)
            {
                Console.WriteLine(el);
            }
        }
    }
}
