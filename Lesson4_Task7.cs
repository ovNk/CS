/*Создайте приложение, проверяющее текст на 
недопустимые слова. Если недопустимое слово найдено, оно
должно быть заменено на набор символов *. По итогам
работы приложения необходимо показать статистику
действий.*/
using System;
using System.Collections.Generic;

namespace Lesson4_Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            string illegal = "die";
            string text = "To be, or not to be, that is the question, " +
                "Whether 'tis nobler in the mind to suffer " +
                "The slings and arrows of outrageous fortune, " +
                "Or to take arms against a sea of troubles, " +
                "And by opposing end them? To die: to sleep; " +
                "No more; and by a sleep to say we end " +
                "The heart-ache and the thousand natural shocks " +
                "That flesh is heir to, 'tis a consummation " +
                "Devoutly to be wish'd. To die, to sleep";

            KeyValuePair<string, int> result = Illegal_word(text, illegal);

            Console.WriteLine($"Text:\n{text}\n\nResult:\n{result.Key}\n\nChanged: {result.Value}");

            return;
        }

        static KeyValuePair<string,int> Illegal_word(string text, string word)
        {
            char[] temp = text.ToCharArray();//временный массив для хранения результата
            int count = 0;//счетчик замен
            int index;//индекс вхождения искомой подстроки
            int t = 0;//счетчик для замены подстроки
            string change = "";//строка с символами для замены пока пуста

            //создаем строку для замены недопустимых слов
            for (int i = 0; i < word.Length; ++i) 
            {
                change += "*";
            }
            
            //индекс первого вхождения искомой подстроки
            index = text.IndexOf(word);
            //пока вхождения найдены
            while(index!=-1)
            {
                ++count;//инк счетчик замен

                //меняем найденную подстроку заглушкой
                for (int i = index; i < index + change.Length; ++i) 
                {
                    temp[i] = change[t++];
                }

                //ищем следующий индекс
                //начиная с позиции старый индекс + длина заглушки
                index = text.IndexOf(word, index + change.Length);
                t = 0;//обнуляем счетчик
            }

            string result = new string(temp);//строка с результатом
            //пара строка + счетчик
            KeyValuePair<string, int> pair = new KeyValuePair<string, int>(result, count);

            return pair;
        }

    }
}
