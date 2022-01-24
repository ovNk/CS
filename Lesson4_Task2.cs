/*Дан двумерный массив размерностью 5×5, заполненный 
случайными числами из диапазона от –100 до 100.
Определить сумму элементов массива, расположенных
между минимальным и максимальным элементами.
 1  2  3  4  5
 6  *  *  *  *
 *  *  *  *  7
 8  9 10 11 12
13 14 15 16 17
*/
using System;

namespace Lesson4_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[,] nums = new int[5, 5];
            int min = 101;//для поиска минимального
            int max = -101;//и максимального
            int row_max = 0;//ряд макс
            int column_max = 0;//столбец макс
            int row_min = 0;//ряд мин
            int column_min = 0;//столбец мин
            int sum = 0;//сумма

            //инициализация, поиск мин/макс, поиск индексов, печать
            for (int i = 0; i < nums.GetLength(0); ++i)
            {
                for (int j = 0; j < nums.GetLength(1); ++j)
                {
                    nums[i, j] = rand.Next(-100, 101);
                    Console.Write($"{nums[i, j], 5} ");
                    if (min > nums[i, j])
                    {
                        min = nums[i, j];
                        row_min = i;
                        column_min = j;
                    }
                    if (max < nums[i, j])
                    {
                        max = nums[i, j];
                        row_max = i;
                        column_max = j;
                    }
                }
                Console.WriteLine();
            }

            //если максимальное в массиве находится перед минимальным
            //меняем местами индексы
            if (row_max < row_min || (row_max == row_min && column_max < column_min))
            {
                int temp = row_max;
                row_max = row_min;
                row_min = temp;
                temp = column_max;
                column_max = column_min;
                column_min = temp;
            }

            //для подсчеты суммы
            //если флаг = 1 - считаем сумму
            int flag = 0;
            for (int i = 0; i < nums.GetLength(1); ++i)
            {
                for (int j = 0; j < nums.GetLength(1); ++j)
                {
                    //если это первый или последний элемент
                    //флаг = 1
                    if ((i == row_min && j == column_min) || (i == row_max && j == column_max)) 
                    {
                        ++flag;
                        sum += nums[i, j];//считаем первый или последний элемент
                        if (flag > 1)//если больше 1 - вся сумма посчитана, выход из циклов
                            break;
                        continue;//иначе продолжаем
                    }
                    if (flag == 1)//считаем сумму пока флаг == 1
                        sum += nums[i, j];
                }
                if (flag > 1)//сумма посчитана, выход из циклов
                    break;
            }

            Console.WriteLine($"Max = {max} Min = {min}\nSum = {sum}");//вывод результата

            return;
        }
    }
}
