/*Пользователь вводит в строку с клавиатуры логическое
выражение. Например, 3>2 или 7<3. Программа должна
посчитать результат введенного выражения и дать результат 
true или false. В строке могут быть только целые числа
и операторы: <, >, <=, >=, ==, !=. Для обработки ошибок
ввода используйте механизм исключений.*/
using System;

namespace Lesson5_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string condition = "285==256";//условие
            string operate = "";//оператор
            bool result = false;
            string[] nums = condition.Split('<', '>', '=', '!');//отделили операнды

            foreach(char ch in condition)//оператор
            {
                if (!Char.IsDigit(ch))
                    operate += ch;
            }

            try
            {
                foreach(char el in nums[0])//первый аргумент - не целое число
                {
                    if (!Char.IsDigit(el))
                        throw new ArgumentException("Arguments must be integers!");
                }

                foreach (char el in nums[2])//второй аргумент - не целое число
                {
                    if (!Char.IsDigit(el))
                        throw new ArgumentException("Arguments must be integers!");
                }

                result = operate switch
                {
                    ">" => Convert.ToInt32(nums[0]) > Convert.ToInt32(nums[2]),
                    "<" => Convert.ToInt32(nums[0]) < Convert.ToInt32(nums[2]),
                    "<=" => Convert.ToInt32(nums[0]) <= Convert.ToInt32(nums[2]),
                    ">=" => Convert.ToInt32(nums[0]) >= Convert.ToInt32(nums[2]),
                    "==" => Convert.ToInt32(nums[0]) == Convert.ToInt32(nums[2]),
                    "!=" => Convert.ToInt32(nums[0]) != Convert.ToInt32(nums[2]),
                    _ => throw new ArgumentException("Invalid operator!"),//оператор введен некорректно
                };

                Console.WriteLine($"{nums[0]} {operate} {nums[2]}   {result}");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"An exception ({ex.GetType().Name}) occurred. {ex.Message}");
            }
            
        }
    }
}
