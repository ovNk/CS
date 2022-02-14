using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_Task1
{
    //Интерфейс для "частей" дома
    interface IPart
    {
        IPart Next { get; }//следующий элемент по проекту
    }
}
