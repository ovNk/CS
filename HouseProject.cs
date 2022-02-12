using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Task1
{
    //Класс представляет проект дома
    static class HouseProject
    {
        //СВОЙСТВА
        public static IPart Basement { get; } = new Basement();
        public static IPart Wall_1 { get; } = new Wall();
        public static IPart Wall_2 { get; } = new Wall();
        public static IPart Wall_3 { get; } = new Wall();
        public static IPart Wall_4 { get; } = new Wall();
        public static IPart Window_1 { get; } = new Window();
        public static IPart Window_2 { get; } = new Window();
        public static IPart Window_3 { get; } = new Window();
        public static IPart Window_4 { get; } = new Window();
        public static IPart Door { get; } = new Door();
        public static IPart Roof { get; } = new Roof();

        public static IPart[] Project = new IPart[]
        {
            Basement, Wall_1,   Wall_2,   Wall_3,
            Wall_4,   Window_1, Window_2, Window_3,
            Window_4, Door,     Roof
        };
    }
}
