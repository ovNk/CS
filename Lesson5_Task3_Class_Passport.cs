using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5_Task3
{
    class Passport
    {
        //ЭКЗЕМПЛЯРНЫЕ ПОЛЯ
        private string first_name;//имя
        private string last_name;//фамилия
        private readonly string number;//номер
        private DateTime date_of_birth;//дата рождения
        private DateTime date_of_issue;//дата выдачи

        //СВОЙСТВА
        public string FirstName//имя
        {
            get => first_name;
            set
            {
                if (value.Length > 50)
                    throw new ArgumentException("The name cannot be longer than 50 characters!");
                first_name = value;
            }
            
        }
        public string LastName//фамилия
        {
            get => last_name;
            set
            {
                if (value.Length > 50)
                    throw new ArgumentException("The last name cannot be longer than 50 characters!");
                last_name = value;
            }
        }
        public string Number//номер
        {
            get
            {
                return number;
            }
        }
        public DateTime DateOfBirth//дата рождения
        {
            get => date_of_birth;
            set
            {
                if (DateTime.Compare(value, DateTime.Parse("01.01.1900")) < 0)
                    throw new ArgumentException("The date of birth cannot be earlier than 01.01.1900!");
                date_of_birth = value;
            }
        }
        public DateTime DateOfIssue//дата выдачи
        {
            get => date_of_issue;
            set
            {
                if (DateTime.Compare(value, DateTime.Parse("01.01.1900")) < 0)
                    throw new ArgumentException("The date of issue cannot be earlier than 01.01.1900!");
                date_of_issue = value;
            }
        }

        //КОНСТРУКТОРЫ
        public Passport(string first_name, string last_name, string number, DateTime date_of_birth, DateTime date_of_issue)
        {
            try
            {
                if (number.Length != 10)
                    throw new ArgumentException("The passport must have 10 digits!");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"An exception ({ex.GetType().Name}) occurred. {ex.Message}");
            }
            this.number = number;
            FirstName = first_name;
            LastName = last_name;
            DateOfBirth = date_of_birth;
            DateOfIssue = date_of_issue;
        }
        public Passport(string first_name, string last_name, string number, string date_of_birth, string date_of_issue)
        {
            try
            {
                if (number.Length != 10)
                    throw new ArgumentException("The passport must have 10 digits!");
                this.number = number;
                FirstName = first_name;
                LastName = last_name;
                DateOfBirth = DateTime.Parse(date_of_birth);
                DateOfIssue = DateTime.Parse(date_of_issue);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"An exception ({ex.GetType().Name}) occurred. {ex.Message}");
            }
            
        }

    }
}
