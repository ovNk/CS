using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_Task1
{
    //Бригадир
    class TeamLeader: IWorker
    {
        //СВОЙСТВА
        public string Report { get; private set; }//рапорт

        //МЕТОДЫ
        public void Build(House house, int index)//функция строительства для бригадира
        {
            //формируем рапорт
            Report = "";

            //от начала массива до текущего индекса
            for (int i = 0; i < index; ++i)
            {
                Report += house[i] + (i < index - 1 ? ", " : ".");
            }
            Console.WriteLine(this);
        }

        //Переопределение ToString()
        public override string ToString()
        {
            return $"Hello, I'm a TeamLeader.\nAt the moment, the team has built:\n{Report}\nThe report is over!\n";
        }
    }
}
