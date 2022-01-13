/*Начальный вклад в банке равен 10000 грн. Через
каждый месяц размер вклада увеличивается на P
процентов от имеющейся суммы (P — вещественное
число, 0 < P < 25). Значение Р программа должна 
получать у пользователя. По данному P определить через
сколько месяцев размер вклада превысит 11000 грн.,
и вывести найденное количество месяцев K (целое
число) и итоговый размер вклада S (вещественное
число).*/

using System;

namespace Lesson1_task2
{
    class Task2
    {
        static void Main(string[] args)
        {
            double deposit = 10000;//начальный вклад
            double max_deposit = 11000;//максимальный вклад
            int k = 0;//количество месяцев

            //ввод процентов по вкладу
            Console.WriteLine("Enter a P: ");
            double p = Convert.ToDouble(Console.ReadLine());
            while (p < 0 || p > 25) //проверка 
            {
                Console.WriteLine("Incorrect P!\n0 < P < 25.\nEnter a P: ");
                p = Convert.ToDouble(Console.ReadLine());
            }
            p /= 100;//для удобства вычислений

            while (deposit < max_deposit) //пока вклад не превысил макс вклад
            {
                deposit += deposit * p;
                ++k;
            }

            //вывод результата
            Console.WriteLine($"Deposit exceeds 11000 after {k} months.\nThe deposit amount is {deposit}.");

            return;
        }
    }
}
