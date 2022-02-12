using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Task1
{
    //Интерфейс для "частей" дома
    interface IPart
    {
        //СВОЙСТВА
        IPart Next { get; }//следующий элемент по проекту
    }
}
