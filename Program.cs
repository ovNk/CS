using System;

namespace Lesson8_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Team team_build = new Team();
                House arr = team_build.Build();
                Console.WriteLine(arr);

            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine($"An exception ({ex.GetType().Name}) occurred. {ex.Message} ");
            }
        }
    }
}
