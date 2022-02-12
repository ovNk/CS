using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Task1
{
    class Basement : IPart
    {
        //СВОЙСТВА
        public IPart Next => new Wall();//для фундамента следующий блок по проекту - стена
        
        //МЕТОДЫ
        public override string ToString()//переопределение ToString() для Basement
        {
            return "Basement";
        }
    }
}
