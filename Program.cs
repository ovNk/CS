using System;

namespace Lesson10
{
    class Program
    {
        static void Main(string[] args)
        {
            Calendar calendar = new Calendar();
            Person person = new Person();
            calendar.Celebrate += person.Enjoy;
            calendar.Celebrate += person.Enjoy;
            calendar.Celebrate += person.Enjoy;
            calendar.Quarter += person.Report;
            calendar.Quarter += person.Report;
            calendar.StartCelebrate();
            calendar.StartQuarter();
        }      
    }
}


