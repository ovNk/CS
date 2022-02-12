using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Task1
{
    //Интерфейс для рабочих
    interface IWorker
    {
        //МЕТОДЫ
        void Build(IPart[] house, int index);//Функция "построить"
    }
}
