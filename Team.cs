using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9_Task1
{
    //Класс представляет бригаду рабочих во главе с бригадиром
    static class Team
    {
       //СВОЙСТВА
        public static IWorker TeamLeader { get; } = new TeamLeader();
        public static IWorker Worker_1 { get; } = new Worker();
        public static IWorker Worker_2 { get; } = new Worker();
        public static IWorker Worker_3 { get; } = new Worker();
        public static IWorker Worker_4 { get; } = new Worker();

        public static IWorker[] team = new IWorker[]
        {
            TeamLeader, Worker_1, Worker_2, Worker_3, Worker_4
        };

        //МЕТОДЫ
        public static void Building(IPart[] new_house)//Функция "построить дом"
        {
            Random rand = new Random();//для выбора рабочего из бригады
            IWorker current;//текущий рабочий
            
            for (int i = 0; i < new_house.Length; ++i)
            {
                current = team[rand.Next(0, team.Length)];//получим текущего

                //пока это бригадир
                while (current is TeamLeader)
                {
                    current.Build(new_house, i);//бригадир формирует отчет
                    current = team[rand.Next(0, team.Length)];//получим следующего
                }

                current.Build(new_house, i);//рабочий строит свой блок
            }

            //финальный вызов бригадира с отчетом
            team[0].Build(new_house, new_house.Length);
        }
    }
}
