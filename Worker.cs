using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Task1
{
    class Worker : IWorker
    {
        //МЕТОДЫ
        public void Build(IPart[] house, int index)//функция строительства для рабочего
        {
            //если это первый элемент - строим фундамент
            //иначе выбираем следующий блок по проекту
            house[index] = index - 1 >= 0 ? HouseProject.Project[index - 1].Next : new Basement();
        }
    }
}
