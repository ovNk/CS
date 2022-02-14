using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_Task1
{
    class Worker : IWorker
    {
        public void Build(House house, int index)
        {
            //если это первый элемент - строим фундамент
            //иначе выбираем следующий блок по проекту
            house[index] = index - 1 >= 0 ? Project.project[index - 1].Next : new Basement();
        }
    }
}
