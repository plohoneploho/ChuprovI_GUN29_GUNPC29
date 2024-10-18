using System;
using System.Collections.Generic;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1 - Последовательность Фибоначчи
            List<int> home_fibonacci = FibonacciSequence(8);
            Console.WriteLine("Последовательность Фибоначчи: " + string.Join(", ", home_fibonacci));

            // Задание 2 - Названия месяцев
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            Console.WriteLine("Названия месяцев: " + string.Join(", ", months));

            // Задание 3 - Матрица 3x3
            int[,] matrix = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = (int)Math.Pow(j + 2, i + 1);
                }
            }
            Console.WriteLine("Матрица 3x3:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Задание 4 - Ломанный массив
            double[][] jaggedArray = new double[3][];
            jaggedArray[0] = new double[] { 1, 2, 3, 4, 5 };
            jaggedArray[1] = new double[] { Math.E, Math.PI };
            jaggedArray[2] = new double[] { Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000) };
            Console.WriteLine("Ломанный массив:");
            foreach (var array in jaggedArray)
            {
                Console.WriteLine(string.Join(", ", array));
            }

            // Задание 5 - Копирование элементов массива
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
            Array.Copy(array1, 0, array2, 0, 3);
            Console.WriteLine("Результат копирования: " + string.Join(", ", array2));
            
            // Задание 6 - Изменение размера массива
            int newSize = 6; // Решил сделать переменную для удобства.

            Array.Resize(ref array1, newSize);
            Console.WriteLine("Измененный размер массива("+newSize+"):" + string.Join(", ", array1));
        }

        static List<int> FibonacciSequence(int n)
        {
            List<int> sequence = new List<int> { 0, 1 };
            while (sequence.Count < n)
            {
                sequence.Add(sequence[sequence.Count - 1] + sequence[sequence.Count - 2]);
            }
            return sequence;
        }
    }
}
