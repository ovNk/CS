using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson6_Task4
{
    class MorseCode
    {
        //ЭКЗЕМПЛЯРНЫЕ ПОЛЯ
        private string request;//запрос
        private string answer;//ответ

        //СТАТИЧЕСКИЕ ПОЛЯ
        static private Dictionary<char, string> alphabet;//словарь: буква - ключ, комбинация морзе -значение
        static string allowed;//допустимые символы

        //СВОЙСТВА
        private string Request
        {
            get => request;
            set
            {
                //входная строка не должна быть null, пустой, и не должна содержать запрещенные символы
                if (value == null || value.Length < 1 || !IsValid(value))
                    throw new ArgumentException("The string contains forbidden characters!");

                //строка подходит
                request = value;
            }
        }
        private string Answer
        {
            get => answer;
        }

        //КОНСТРУКТОРЫ
        public MorseCode(string request)
        {
            Request = request;
            answer = "";
        }
        static MorseCode()
        {
            alphabet = new Dictionary<char, string>();
            
            //инициализируем словарь
            alphabet.Add('A', ".-");
            alphabet.Add('B', "-...");
            alphabet.Add('C', "-.-.");
            alphabet.Add('D', "-..");
            alphabet.Add('E', ".");
            alphabet.Add('F',"..-.");
            alphabet.Add('G',"--.");
            alphabet.Add('H',"....");
            alphabet.Add('I',"..");
            alphabet.Add('J',".---");
            alphabet.Add('K',"-.-");
            alphabet.Add('L',".-..");
            alphabet.Add('M',"--");
            alphabet.Add('N',"-.");
            alphabet.Add('O',"---");
            alphabet.Add('P',".--.");
            alphabet.Add('Q',"--.-");
            alphabet.Add('R',".-.");
            alphabet.Add('S',"...");
            alphabet.Add('T',"-");
            alphabet.Add('U',"..-");
            alphabet.Add('V',"...-");
            alphabet.Add('W',".--");
            alphabet.Add('X',"-..-");
            alphabet.Add('Y',"-.--");
            alphabet.Add('Z',"--..");
            alphabet.Add('1',".----");
            alphabet.Add('2',"..---");
            alphabet.Add('3',"...--");
            alphabet.Add('4',"....-");
            alphabet.Add('5',".....");
            alphabet.Add('6',"-....");
            alphabet.Add('7',"--...");
            alphabet.Add('8',"---..");
            alphabet.Add('9',"----.");
            alphabet.Add('0',"-----");
            alphabet.Add('.',".-.-.-");
            alphabet.Add(',',"--..--");
            alphabet.Add(':',"---...");
            alphabet.Add('?',"..--..");
            alphabet.Add('\'',".----.");
            alphabet.Add('-',"-....-");
            alphabet.Add('(', "-.--.");
            alphabet.Add(')', "-.--.-");
            alphabet.Add('/', "-..-.");
            alphabet.Add('"', ".-..-.");
            alphabet.Add(';', "-.-.-.");
            alphabet.Add('!', "-.-.--");
            alphabet.Add('+', ".-.-.");
            alphabet.Add('=', "-...-");
            alphabet.Add(' ', "   ");

            //допустимые символы - все ключи словаря
            allowed = "";
            foreach(char el in alphabet.Keys)
                allowed += el;
        }

        //МЕТОДЫ
        private bool IsValid(string request)//проверка на запрещенные символы
        {
            foreach(char el in request)
            {
                //проходим по входной строке
                //и проверяем, содержит ли строка с допустимыми символами
                //текущий символ входной строки
                if (!allowed.Contains(Char.ToUpper(el)))//не содержит
                    return false;
            }

            return true;
        }

        public void Translator()//переводчик 
        {
            //если входная строка закодирована азбукой Морзе
            if (IsEncrypted())
            {
                Decrypt();//раскодируем
            }
            else//иначе закодируем азбукой Морзе
            {
                Encrypt();
            }
        }

        private bool IsEncrypted()//проверка в каком виде находится входная строка
        {
            Dictionary<char, string>.ValueCollection valColl = alphabet.Values;//коллекция значений из словаря
            
            foreach(string el in valColl)//если входная строка содержит значение("букву" азбуки Морзе))
            {
                if (Request.Contains(el)) 
                    return true;//строка закодирована
            }

            return false;
        }
        private void Encrypt()
        {
            //зашифруем
            for (int i = 0; i < Request.Length; ++i)
            {
                //добавим к ответу значение из словаря,
                //где ключ - текущий символ входной строки
                answer += alphabet[Char.ToUpper(request[i])];

                //если текущий символ - пробел
                //добавим к ответу 3 пробела(промежуток между словами)
                if (Request[i] == ' ')
                    answer += "   ";
                //иначе добавим 1 пробел(промежуток между "буквами")
                else
                    answer += " ";
            }
        }
        private void Decrypt()
        {
            //расшифруем

            //сначала делим входную строку на "слова"
            string[] words = Request.Split("   ");
            
            //проходим циклом по массиву с получившимися "словами"
            for (int i = 0; i < words.Length; ++i)
            {
                //делим "слово" на "буквы"
                string[] temp = words[i].Split(" ");

                //костыль:D
                //исключаем случай, когда в массиве только пустая строка
                if (temp.Length == 1 && temp[0] == "")
                    continue;

                //проходим по массиву "букв"
                for (int j = 0; j < temp.Length; ++j)
                {
                    //опять костыль:D
                    //исключаем пустые строки
                    if (temp[j] == "")
                        continue;
                    //добавим к результату
                    //ключ из словаря, которому соответствует значение - текущая "буква"
                    else
                        answer += alphabet.Where(x => x.Value == temp[j]).FirstOrDefault().Key;
                }
                answer += " ";//"слово" добавлено, добавим пробел
            }
             
        }

        public string Print()
        {
            return Answer;//вернем строку-результат
        }

    }
}
