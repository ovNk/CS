using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_Task1
{
    class Roof : IPart
    {
        //СВОЙСТВА
        public IPart Next => null;//для крыши следующего блока нет, она последняя по проекту


        //МЕТОДЫ
        public override string ToString()//переопределение ToString() для Roof
        {
            return "Roof";
        }
    }
}
