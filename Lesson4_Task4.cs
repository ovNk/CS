/*
Создайте приложение, которое производит операции
над матрицами:
■■Умножение матрицы на число;
■■Сложение матриц;
■■Произведение матриц.*/
using System;

namespace Lesson4_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] m_a = new int[3, 2] { { 2, 3 }, { 4, 5 }, { 1, 5 } };
            int[,] m_b = new int[2, 4] { { 1, 2, 3, 1 }, { 2, 3, 2, 1 } };
            int[,] result;
            //Умножение на число
            Console.WriteLine("Multiplying a matrix A by a number 3:\n" +
                "Matrix A:");
            result = Mult(m_a, 3);
            Print(m_a);
            Console.WriteLine("Result:");
            Print(result);

            //сложение
            Console.WriteLine("\nAddition of matrices A and B:\n" +
                "Matrix A:");
            result = Addition(m_a, m_b);
            Print(m_a);
            Console.WriteLine("Matrix B:");
            Print(m_b);
            Console.WriteLine("Result:");
            if (result != null) 
                Print(result);
            else
                Console.WriteLine("Matrices are incompatible!\n");

            //произведение
            Console.WriteLine("\nThe product of matrices A and B:\nMatrix A:");
            result = Product(m_a, m_b);
            Print(m_a);
            Console.WriteLine("Matrix B:");
            Print(m_b);
            Console.WriteLine("Result:");
            if (result != null)
                Print(result);
            else
                Console.WriteLine("Matrices are incompatible!\n");

            return;
        }

        static int[,] Mult(int[,] matrix, int x)//умножение на число
        {
            //результат
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];

            //каждый элемент умножаем на число
            for (int i = 0; i < result.GetLength(0); ++i)
            {
                for (int j = 0; j < result.GetLength(1); ++j)
                {
                    result[i, j] = matrix[i, j] * x;
                }
            }

            return result;
        }

        static int[,] Addition(int[,] matrix_a, int[,] matrix_b)//сложение
        {
            //матрицы должны быть одинаковой размерности
            if (matrix_a.GetLength(0) != matrix_b.GetLength(0) || matrix_a.GetLength(1) != matrix_b.GetLength(1))
                return null;

            //результат
            int[,] result = new int[matrix_a.GetLength(0), matrix_a.GetLength(1)];

            //складываем элементы попарно
            for (int i = 0; i < result.GetLength(0); ++i)
            {
                for (int j = 0; j < result.GetLength(1); ++j)
                {
                    result[i, j] = matrix_a[i, j] + matrix_b[i, j];
                }
            }

            return result;
        }

        static int[,] Product(int[,] matrix_a, int[,] matrix_b)//произведение
        {
            if (matrix_a.GetLength(1) != matrix_b.GetLength(0)) //если матрицы несовместимы (столбцы А != строки В)
                return null;

            //результат
            int[,] result = new int[matrix_a.GetLength(0), matrix_b.GetLength(1)];

            int temp = 0;//переменная для подсчета элементов матрицы
            int t = 0;//счетчик

            for (int i = 0; i < result.GetLength(0); ++i)
            {
                for (int j = 0; j < result.GetLength(1); ++j)
                {
                    while (t < matrix_b.GetLength(0))//считаем элемент строки i столбца j
                    {
                        //у матрицы А изменяется столбец
                        //у В строка
                        temp += matrix_a[i, t] * matrix_b[t++, j];
                    }
                    //результат подсчитан
                    result[i, j] = temp;

                    t = 0;//сбрасываем счетчик на 0
                    temp = 0;//временную переменную на 0
                }
            }

            return result;
        }

        static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write($"{matrix[i, j],5} ");
                }
                Console.WriteLine();
            }
        }
    }

}
