/*Создайте класс «Заграничный паспорт». Вам необходимо
хранить информацию о номере паспорта, ФИО владельца,
дате выдачи и т.д. Предусмотреть механизмы для 
инициализации полей класса. Если значение для инициализации
неверное, генерируйте исключение.*/
using System;

namespace Lesson5_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Passport ob = new Passport("Olga", "Nikishina", "4611357078", "01.01.1999", "01.01.1999");
            ob.LastName = "gggggggggggggggggggggggggggggggggggggggggggggggggggggg";



        }
    }
}
