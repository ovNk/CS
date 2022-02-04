/*Ранее в одном из практических заданий вы создавали
класс «Матрицы».  Выполните перегрузку
+ (для сложения матриц), — (для вычитания матриц), == и !=(для проверки на равенство 
матриц), а также * для произведения матриц и умножения матриц на число. Используйте
механизм свойств для полей класса.*/
using System;

namespace Lesson6_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix_1 = new Matrix(3, 3);
            Matrix matrix_2 = new Matrix(3, 3);
            Matrix matrix_3;

            //инициализация
            matrix_1.InitRandom();
            matrix_1.Print();
            matrix_2.InitRandom();
            matrix_2.Print();

            //вычитание
            matrix_3 = matrix_1 - matrix_2;
            matrix_3.Print();

            //сложение
            matrix_3 = matrix_1 + matrix_2;
            matrix_3.Print();

            //умножение на число
            matrix_3 = matrix_1 * 2;
            matrix_3.Print();

            //произведение
            matrix_3 = matrix_1 * matrix_2;
            matrix_3.Print();

            //индексаторы
            matrix_3[0, 0] = 0;
            matrix_3.Print();
            Console.WriteLine(matrix_3[0, 0]);

            return;
        }
    }
}
