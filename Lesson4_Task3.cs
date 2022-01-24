/*Задание 3
Пользователь вводит строку с клавиатуры. Необходи-
мо зашифровать данную строку используя шифр Цезаря.
Из Википедии:
ДОМАШНЕЕ ЗАДАНИЕ
1
Шифр Цезаря — это вид шифра подстановки, в ко-
тором каждый символ в открытом тексте заменяется
символом, находящимся на некотором постоянном числе
позиций левее или правее него в алфавите. Например,
в шифре со сдвигом вправо на 3, A была бы заменена на
D, B станет E, и так далее.
Подробнее тут: https://en.wikipedia.org/wiki/Caesar_
cipher.
Кроме механизма шифровки, реализуйте механизм
расшифрования.*/

using System;

namespace Lesson4_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Шифр Цезаря — это вид шифра подстановки," +
                " в котором каждый символ в открытом тексте заменяется символом," +
                " находящимся на некотором постоянном числе позиций левее или правее" +
                " него в алфавите.";
            
            Console.WriteLine($"{text}\n");//исходный текст

            string enc = encoder(text, 1);//зашифрованная строка
            string dec = decoder(enc, 1);//расшифрованная строка

            Console.WriteLine($"{enc}\n");//вывод зашифрованной строки
            Console.WriteLine($"{dec}\n");//и расшифрованной

            return;

        }

        static string encoder(string text, int shift)//шифруем
        {
            char[] result = new char[text.Length];
            char start = (char)('а' - 1);//позиция первой буквы алфавита
            char end = 'я';//позиция последней буквы алфавита

            //если сдвиг больше, чем количество букв в алфавите
            shift = (shift > 33 ? shift - 33 : shift);
            
            //шифр
            for (int i = 0; i < text.Length; ++i)
            {
                //если символ - буква
                if (Char.IsLetter(text[i]))
                {
                    //если буква верхнего регистра
                    if (Char.IsUpper(text[i]))
                    {
                        //меняем позицию первой и последней
                        //буквы на буквы верхнего регистра
                        start = (char)('А' - 1);
                        end = 'Я';
                    }
                    //если нижнего
                    else
                    {
                        //меняем позиции на нижний
                        start = (char)('а' - 1);
                        end = 'я';
                    }

                    //если при сдвиге происходит выход за границы алфавита
                    if ((char)(text[i] + shift) > end)//пересчитываем сдвиг от начала
                        result[i] = (char)(start + (shift - end + text[i]));
                    //иначе просто сдвигаем буквы
                    else
                        result[i] = (char)(text[i] + shift);

                }
                else//если символ не буква - просто добавим его к результату
                    result[i] = text[i];
            }

            //создадим строку с результатом
            string res = new string(result);
            return res;//и вернем ее

        }

        static string decoder(string text, int shift)//расшифровка
        {
            char[] result = new char[text.Length];
            char start = 'а';//позиция первой буквы алфавита
            char end = (char)('я' - 1);//позиция последней буквы алфавита

            //если сдвиг больше, чем количество букв в алфавите
            shift = (shift > 33 ? shift - 33 : shift);

            //расшифровка
            for (int i = 0; i < text.Length; ++i)
            {
                //если символ - буква
                if (Char.IsLetter(text[i]))
                {
                    //верхнего регистра
                    if (Char.IsUpper(text[i]))
                    {
                        start = 'А';
                        end = (char)('Я' + 1);
                    }
                    //нижнего регистра
                    else
                    {
                        start = 'а';
                        end = (char)('я' + 1);
                    }

                    //если при сдвиге происходит выход за границы алфавита
                    if ((char)(text[i] - shift) < start)//пересчитываем сдвиг от конца
                        result[i] = (char)(end - (shift - start + text[i]));
                    else//иначе просто сдвигаем буквы
                        result[i] = (char)(text[i] - shift);

                }
                else//если символ не буква - просто добавим его к результату
                    result[i] = text[i];

            }

            //создадим строку с результатом
            string res = new string(result);
            return res;//и вернем ее

        }
        
    }
}
