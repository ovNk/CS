using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_Task1
{
    class Window : IPart
    {
        //СВОЙСТВА

        //для окна следующий блок по проекту - окно или дверь
        public IPart Next => count < 4 ? new Window() : new Door();


        //СТАТИЧЕСКИЕ ПОЛЯ

        //статическая переменная для хранения информации
        //о том, какое по счету окно строим на данный момент
        private static int count = 0;


        //КОНСТРУКТОРЫ
        public Window()
        {
            //после 4 окна сбрасываем счетчик в 0
            if (count >= 4)
                count = 0;

            //инк счетчик
            ++count;
        }


        //МЕТОДЫ
        public override string ToString()//переопределение ToString() для Window
        {
            return "Window";
        }
    }
}
