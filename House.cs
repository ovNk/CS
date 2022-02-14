using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8_Task1
{
    class House
    {
        private IPart[] parts;
        public int Size { get => 11; }
        public House()
        {
            parts = new IPart[Size];
        }

        public IPart this[int index]
        {
            get
            {
                if (index < 0 || index >= parts.Length)//выход за границы массива
                    throw new IndexOutOfRangeException($"The index is out of range!" +
                        $" Available indexes 0 - 10, an attempt to access index {index} was recorded!");
                return parts[index];
            }
            
            set
            {
                if (index < 0 || index >= parts.Length)//выход за границы массива
                    throw new IndexOutOfRangeException($"The index is out of range!" +
                        $" Available indexes 0 - 10, an attempt to access index {index} was recorded!");
                parts[index] = value;
            }
        }

        public override string ToString()
        {
            string result = "Full building:\n";
            foreach(IPart el in parts)
            {
                result += el.ToString();
                result += "\n";
            }
            return result;
        }
    }
}
