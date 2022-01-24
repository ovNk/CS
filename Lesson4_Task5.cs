/*Пользователь с клавиатуры вводит в строку ариф-
метическое выражение. Приложение должно посчитать
его результат.
Для решения использовался хабр со статьей об обратной польской записи
//https://habr.com/ru/post/100869/
//а также материалы по ней же
//http://www.interface.ru/home.asp?artId=1492
*/

using System;
using System.Collections.Generic;

namespace Lesson4_Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            //строку вводить с пробелами для удобства разделения на операнды и операторы
            //ОБЯЗАТЕЛЬНО!

            //string expression = "3 + 5 - 2 * ( 3 + 2 )";+++
            //string expression = "9 + 4 - 8 * 7";+++
            string expression;
            Console.WriteLine("Expression: ");
            expression = Console.ReadLine();

            string[] nums = expression.Split(' ');//разделяем 
            string[] res = Revers_polish_notation(nums);//получем обратную польскую запись
          
            Console.WriteLine(Calculate(res));//вывод результата

            return;
        }

        static string[] Revers_polish_notation(string[] nums)
        {
            Stack<string> symb = new Stack<string>();//стэк для символов
            //ассоциативный массив для представления приоритета операций
            Dictionary<string, int> priority = new Dictionary<string, int>(6)
            {
                { "*", 3 },
                { "/", 3 },
                { "+", 2 },
                { "-", 2 },
                { "(", 1 },
                { ")", 1 }
            };

            //временный массив для записи выражения в обратной польской нотации
            string[] temp = new string[nums.Length];
            //индекс для записи в temp
            int index = 0;

            //итерация по nums
            foreach (string str in nums)
            {
                //если оператор
                if (str == "*" || str == "/" || str == "+" || str == "-" || str == "(" || str == ")") 
                {
                    //если в стеке есть открытая скобка
                    //и текущий оператор -  не закрывающая скобка
                    if (symb.Contains("(") && str!=")")
                    {
                        symb.Push(str);//добавим оператор в стек
                    }
                    //если текущий символ - закрывающая скобка
                    else if (str == ")")
                    {
                        while (symb.Peek() != "(")//пока не дойдем до открытой скобки
                            temp[index++] = symb.Pop();//добавляем в массив операторы
                        symb.Pop();//удаляем скобку из стека
                    }
                    //если стек не пустой
                    //и приоритет текущего оператора выше, чем у верхнего в стеке
                    else if (symb.Count == 0 || priority[str] > priority[symb.Peek()] || str == "(")
                        symb.Push(str);//добавляем оператор в стек
                    //если стек не пустой
                    //и приоритет текущего оператора ниже или равен приоритету верхнего в стеке
                    else if(symb.Count > 0 && priority[str] <= priority[symb.Peek()])
                    {
                        //добавляем операторы из стека в массив, пока верно условие
                        while (symb.Count > 0 && priority[str] <= priority[symb.Peek()] ) 
                            temp[index++] = symb.Pop();
                        symb.Push(str);//и добавляем оператор в стек
                    }
                    
                }
                else//если операнд
                    temp[index++] = str;//добавляем в массив

            }
            //если строка обработана
            //а операторы в стеке остались
            //добавляем операторы в массив
            while (symb.Count > 0)
                temp[index++] = symb.Pop();

            string[] reverse = new string[index];//"сжимаем" массив до нужного размера

            for (int j = 0; j < index; ++j)//и копируем в него временный массив
            {
                reverse[j] = temp[j];
            }

            return reverse;//возвращаем выражение в обратной польской записи
        }

        static string Calculate(string[] reverse)
        {
            //если строка - число, добавляем в стек
            //если оператор - вынимаем из стека 2 верхних операнда
            //считаем результат и добавляем в стек

            Stack<string> calc = new Stack<string>();//стек для вычислений

            foreach (string str in reverse)
            {
                //если оператор
                if (str == "*" || str == "/" || str == "+" || str == "-" || str == "(" || str == ")")
                {
                    double second = Convert.ToDouble(calc.Pop());//вынимаем 
                    double first = Convert.ToDouble(calc.Pop());//два верхних значения

                    //выбор операции
                    switch (str)
                    {
                        case "*":
                            calc.Push(Convert.ToString(first * second));
                            break;
                        case "/":
                            calc.Push(Convert.ToString(first / second));
                            break;
                        case "+":
                            calc.Push(Convert.ToString(first + second));
                            break;
                        case "-":
                            calc.Push(Convert.ToString(first - second));
                            break;
                    }
                }
                else//если операнд - добавим в стек
                {
                    calc.Push(str);
                }
            }

            return calc.Pop();//возвращаем единственное значение в стеке, представляющее результат вычислений
        }
    }
}
