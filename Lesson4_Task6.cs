/*Пользователь с клавиатуры вводит некоторый текст.
Приложение должно изменять регистр первой буквы
каждого предложения на букву в верхнем регистре.

Например, если пользователь ввёл: «today is a good
day for walking. i will try to walk near the sea».
Результат работы приложения: «Today is a good day
for walking. I will try to walk near the sea».*/

using System;

namespace Lesson4_Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = "today is a good day for walking.i will try to walk near the sea!";
            string text;
            text = Console.ReadLine();
            string result = Register(text);
            Console.WriteLine($"Text:\n{text}\n\nResult:\n{result}");
            return;
        }

        static string Register(string text)
        {
            //временный массив для хранения результата
            char[] temp = text.ToCharArray();
            
            for (int i = 0; i < text.Length; ++i)
            {
                //сначала копируем текущий символ в массив
                temp[i] = text[i];

                //если текущий символ - . или ? или !
                //изменяем регистр следующей буквы на верхний
                //и инк счетчик для перехода сразу на 2 буквы вперед
                if ((text[i] == '.' || text[i] == '?' || text[i] == '!') && i + 1 < text.Length)  
                    temp[++i] = Char.ToUpper(text[i]);
            }

            //меняем регистр первой буквы
            temp[0] = Char.ToUpper(temp[0]);

            //результат
            string result = new string(temp);

            return result;
        }
    }
}
