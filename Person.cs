using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10
{
    class Person
    {
        public void Enjoy(string name)
        {
            Console.WriteLine($"Enjoy, {name}!");
        }
        public void Report(DateTime date)
        {
            Console.WriteLine($"Report: {date}.");
        }
    }
}
