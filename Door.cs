using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Task1
{
    class Door : IPart
    {
        //СВОЙСТВА
        public IPart Next => new Roof();//для двери следующий блок по проекту - крыша


        //МЕТОДЫ
        public override string ToString()//переопределение ToString() для Door
        {
            return "Door";
        }
    }
}
