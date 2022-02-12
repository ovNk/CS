/*Задание 1. Реализовать программу “Строительство дома”
Реализовать:
•	 Классы
■ House (Дом), Basement (Фундамент), Walls (Стены),
Door (Дверь), Window (Окно), Roof (Крыша);
■ Team (Бригада строителей), Worker (Строитель),
TeamLeader (Бригадир).
•	 Интерфейсы
■ IWorker, IPart.

Все части дома должны реализовать интерфейс IPart
(Часть дома), для рабочих и бригадира предоставляется
базовый интерфейс IWorker (Рабочий).
Домашнее задание №6 Бригада строителей (Team) строит дом (House). Дом
состоит из фундамента (Basement), стен (Wall), окон
(Window), дверей (Door), крыши (Part).
Согласно проекту, в доме должно быть 1 фундамент,
4 стены, 1 дверь, 4 окна и 1 крыша.
Бригада начинает работу, и строители последовательно
“строят” дом, начиная с фундамента. Каждый строитель
не знает заранее, на чём завершился предыдущий этап
строительства, поэтому он “проверяет”, что уже построено и
продолжает работу. Если в игру вступает бригадир
(TeamLeader), он не строит, а формирует отчёт, что уже
построено и какая часть работы выполнена.
В конечном итоге на консоль выводится сообщение, что
строительство дома завершено и отображается “рисунок
дома” (вариант отображения выбрать самостоятельно).*/
using System;

namespace Lesson9_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random rand = new Random();
            //IWorker current;
            IPart[] new_house = new IPart[HouseProject.Project.Length];//массив для нового дома
            Team.Building(new_house);//строим
            //for (int i = 0; i < new_house.Length; ++i)
            //{
            //    current = Team.team[rand.Next(0, Team.team.Length)];
                
            //    while (current is TeamLeader) 
            //    {
            //        current.Build(new_house, i);
            //        current = Team.team[rand.Next(0, Team.team.Length)];
            //    }

            //    current.Build(new_house, i);
            //}

            //Team.team[0].Build(new_house, new_house.Length);
        }
    }
}
