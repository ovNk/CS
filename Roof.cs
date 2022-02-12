using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Task1
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
