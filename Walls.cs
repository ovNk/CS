using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_Task1
{
    class Walls: IPart
    {
        //СВОЙСТВА

        //для стены следующий блок по проекту - стена или окно
        public IPart Next => count < 4 ? new Walls() : new Window();


        //СТАТИЧЕСКИЕ ПОЛЯ

        //статическая переменная для хранения информации
        //о том, какую по счету стену строим на данный момент
        public static int count = 0;


        //КОНСТРУКТОРЫ
        public Walls()
        {
            //после 4 стены сбрасываем счетчик в 0
            if (count >= 4)
                count = 0;

            //инк счетчик
            ++count;
        }


        //МЕТОДЫ
        public override string ToString()//переопределение ToString() для Wall
        {
            return "Wall";
        }
    }
}
