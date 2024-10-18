using System;

namespace HomeWork_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1: Первые 10 чисел Фибоначчи
            Console.WriteLine("Первые 10 чисел Фибоначчи");
            int a = 0, b = 1;
            Console.Write(a + " " + b + " ");
            for (int i = 2; i < 10; i++)
            {
                int next = a + b;
                Console.Write(next + " ");
                a = b;
                b = next;
            }
            Console.WriteLine();

            // Задание 2: Все четные числа от 2 до 20
            Console.WriteLine("\nВсе четные числа от 2 до 20");
            for (int i = 2; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // Задание 3: Таблица умножения от 1 до 5
            Console.WriteLine("\nТаблица умножения от 1 до 5");
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write((i * j).ToString().PadLeft(3) + " ");
                }
                Console.WriteLine();
            }

            // Задание 4: Проверка пароля
            Console.WriteLine("\nПроверка пароля");
            string password = "netology";
            string userInput;
            do
            {
                Console.Write("Введите пароль: ");
                userInput = Console.ReadLine();
            }
            while (userInput != password);
            Console.WriteLine("Пароль верный!");
        }
    }
}
