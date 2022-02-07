/*Создайте приложение для перевода обычного текста
в азбуку Морзе. Пользователь вводит текст. Приложение
отображает введенный текст азбукой Морзе.
"Буквы" отделяются друг от друга 1 пробелом.
"Слова" - тремя*/
using System;

namespace Lesson6_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //создадим объект для расшифровки
                MorseCode ob = new MorseCode("Hello, world!");
                ob.Translator();//расшифровали
                string answ = ob.Print();

                //создадим объект для зашифровки
                MorseCode reverse = new MorseCode(answ);
                reverse.Translator();//зашифровали
                string rev = reverse.Print();

                //создадим объект для обратной расшифровки
                MorseCode reverse2 = new MorseCode(rev);
                reverse2.Translator();//расшифровали
                string rev2 = reverse2.Print();

                //проверка
                Console.WriteLine(answ);
                Console.WriteLine(rev);
                Console.WriteLine(rev2);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"An exception ({ex.GetType().Name}) occurred. {ex.Message} ");
            }
        }
    }
}
