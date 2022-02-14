using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_Task1
{
    class Basement: IPart
    {
        //СВОЙСТВА
        public IPart Next => new Walls();//для фундамента следующий блок по проекту - стена

        //МЕТОДЫ
        public override string ToString()//переопределение ToString() для Basement
        {
            return "Basement";
        }
    }
}
