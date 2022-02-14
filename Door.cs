using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_Task1
{
    //Дверь
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
