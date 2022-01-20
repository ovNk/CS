/*
Получить с клавиатуры номер дня в году.
Узнать номер недели.
*/
using System;

namespace Lesson3_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int day;//номер дня в году
            int year;//год
            int week = 0;//неделя

            Console.Write("Day: ");
            day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Year: ");
            year = Convert.ToInt32(Console.ReadLine());

            //создадим объект datetime для определения дня недели, приходящегося на 1 января нужного года
            DateTime date = new DateTime(year, 1, 1);

            switch(date.DayOfWeek)
            {
                //если дни не делятся без остатка на 7 ->
                //относятся к следующей неделе ->
                //добавим неделю к результату(+2 в случае если 1 января - не понедельник)
                //***********************************************************************
                //если понедельник - дни остаются без изменений
                //в остальных случаях отнимаем дни до ближайшего понедельника, и добавим +1 к неделям
                case DayOfWeek.Monday:
                    week = (day % 7 == 0 ? day / 7 : day / 7 + 1);
                    break;
                case DayOfWeek.Tuesday:
                    day -= 6;
                    week = (day % 7 == 0 ? day / 7 + 1 : day / 7 + 2);
                    break;
                case DayOfWeek.Thursday:
                    day -= 5;
                    week = (day % 7 == 0 ? day / 7 + 1 : day / 7 + 2);
                    break;
                case DayOfWeek.Wednesday:
                    day -= 4;
                    week = (day % 7 == 0 ? day / 7 + 1 : day / 7 + 2);
                    break;
                case DayOfWeek.Friday:
                    day -= 3;
                    week = (day % 7 == 0 ? day / 7 + 1 : day / 7 + 2);
                    break;
                case DayOfWeek.Saturday:
                    day -= 2;
                    week = (day % 7 == 0 ? day / 7 + 1 : day / 7 + 2);
                    break;
                case DayOfWeek.Sunday:
                    day -= 1;
                    week = (day % 7 == 0 ? day / 7 + 1 : day / 7 + 2);
                    break;
            }

            Console.WriteLine($"Number of week: {week}");
            
            return;
        }
    }
}
