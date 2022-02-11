using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_Task1
{
    class Team
    {
        //ПОЛЯ
        private IWorker[] team;
        
        //СВОЙСТВА
        public int Size { get => 5; }

        //КОНСТРУКТОРЫ
        public Team()
        {
            //в массив будет помещен
            //только один бригадир
            // rand == 0 - бригадир, 1 - рабочий
            Random random = new Random();
            bool flag = true;//переменная-флаг для бригадира
            int rand;
            int r_min = 0;//рандом от
            int r_max = 2;//рандом до
            team = new IWorker[Size];

            for (int i = 0; i < team.Length; ++i)
            {
                rand = random.Next(r_min, r_max);
                if (flag && rand == 0) 
                {
                    team[i] = new TeamLeader();
                    flag = false;
                }
                else
                    team[i] = new Worker();
            }
        }

        
        //МЕТОДЫ
        public House Build()//строим дом
        {
            House house = new House();
            Random rand = new Random();

            for (int i = 0; i < house.Size; ++i) 
            {
                IWorker current_worker = team[rand.Next(0, team.Length)];//выбираем случайного рабочего из массива рабочих

                //если и пока это бригадир
                while (current_worker is TeamLeader && i >= 0 && i < house.Size) 
                {
                    Console.WriteLine(current_worker);//отчет бригадира
                    int j = 0;//для прохода от начала массива
                    while (j < i)
                    {
                        Console.WriteLine(house[j++].ToString());//печатаем что построено
                    }
                    Console.WriteLine("The report is over!\n");//отчет закончен
                    current_worker = team[rand.Next(0, team.Length)];//выбираем следующего рабочего 
                }

                //начало массива - строим фундамент
                if (i == 0)
                {
                    house[i] = new Basement();
                }
                //если предыдущий элемент - фундамент
                //строим стену
                else if(house[i - 1] is Basement)
                {
                    house[i] = new Walls();
                }
                //если предыдущий элемент - стена
                //считаем сколько уже стен построено из 4
                else if(house[i - 1] is Walls)
                {
                    int count = 0;
                    int index = i - 1;
                    while (house[index] is Walls && index > 0)
                    {
                        ++count;
                        --index;
                    }
                    //построено меньше 4 -> строим стену
                    if (count < 4)
                        house[i] = new Walls();
                    //построено 4 -> строим окно
                    else
                        house[i] = new Window();

                }
                //если предыдущий элемент - окно
                //считаем сколько уже окон построено из 4
                else if (house[i - 1] is Window)
                {
                    int count = 0;
                    int index = i - 1;
                    while (house[index] is Window && index > 0)
                    {
                        ++count;
                        --index;
                    }
                    //построено меньше 4 -> строим окно
                    if (count < 4)
                        house[i] = new Window();
                    //построено 4 -> строим дверь
                    else
                        house[i] = new Door();

                }
                //если предыдущий элемент - дверь
                //строим крышу и заканчиваем работу
                else if (house[i - 1] is Door)
                {
                    house[i] = new Roof();
                    break;
                }
            }

            //возвращаем построенный дом
            return house;
        }

        
    }
}
