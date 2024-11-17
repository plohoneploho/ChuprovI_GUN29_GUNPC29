using System;
using System.Collections.Generic;

namespace HomeWork_Collections
{
    internal class Program
    {
        // 1 задача
        private class ListTask
        {
            private readonly List<string> _listOfStrings = new();

            public void TaskLoop()
            {
                Console.WriteLine("Введите строки для добавления в список (или \"-exit\" для выхода):");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "-exit")
                        break;

                    _listOfStrings.Add(input);
                    Console.WriteLine("Список на данный момент:");
                    _listOfStrings.ForEach(Console.WriteLine);

                    Console.WriteLine("Введите строку для добавления в середину списка:");
                    input = Console.ReadLine();
                    if (input == "-exit")
                        break;

                    _listOfStrings.Insert(_listOfStrings.Count / 2, input);
                    Console.WriteLine("Список после добавления в середину:");
                    _listOfStrings.ForEach(Console.WriteLine);
                }
            }
        }

        // 2 задача
        private class DictionaryTask
        {
            private readonly Dictionary<string, int> _studentGrades = new();

            public void TaskLoop()
            {
                Console.WriteLine("Введите имя студента и его оценку (или \"-exit\" для выхода):");
                while (true)
                {
                    Console.Write("Имя: ");
                    string name = Console.ReadLine();
                    if (name == "-exit")
                        break;

                    Console.Write("Оценка (2-5): ");
                    if (!int.TryParse(Console.ReadLine(), out int grade) || grade < 2 || grade > 5)
                    {
                        Console.WriteLine("Ошибка ввода. Попробуйте снова.");
                        continue;
                    }

                    _studentGrades[name] = grade;
                    Console.WriteLine($"Добавлено: {name} с оценкой {grade}");

                    Console.Write("Введите имя студента для поиска (или \"-exit\" для выхода): ");
                    string searchName = Console.ReadLine();
                    if (searchName == "-exit")
                        break;

                    if (_studentGrades.TryGetValue(searchName, out int searchGrade))
                        Console.WriteLine($"Оценка студента {searchName}: {searchGrade}");
                    else
                        Console.WriteLine($"Студент с именем {searchName} не найден.");
                }
            }
        }

        // 3 задача
        private class DoublyLinkedListTask
        {
            private class Node
            {
                public string Value { get; set; }
                public Node Next { get; set; }
                public Node Prev { get; set; }
            }

            private Node _head;
            private Node _tail;

            public void TaskLoop()
            {
                Console.WriteLine("Введите от 3 до 6 элементов для двусвязного списка:");
                for (int i = 0; i < 6; i++)
                {
                    string input = Console.ReadLine();
                    if (input == "-exit" || i >= 2 && string.IsNullOrWhiteSpace(input))
                        break;

                    Add(input);
                }

                Console.WriteLine("Список в прямом порядке:");
                PrintForward();
                Console.WriteLine("Список в обратном порядке:");
                PrintBackward();
            }

            private void Add(string value)
            {
                var node = new Node { Value = value };
                if (_tail == null)
                {
                    _head = node;
                    _tail = node;
                }
                else
                {
                    _tail.Next = node;
                    node.Prev = _tail;
                    _tail = node;
                }
            }

            private void PrintForward()
            {
                var current = _head;
                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Next;
                }
            }

            private void PrintBackward()
            {
                var current = _tail;
                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Prev;
                }
            }
        }

        // Начало
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1, 2 или 3 для выполнения соответствующей задачи (или \"-exit\" для выхода):");
            if (int.TryParse(Console.ReadLine(), out int task))
            {
                switch (task)
                {
                    case 1:
                        var listTask = new ListTask();
                        listTask.TaskLoop();
                        break;
                    case 2:
                        var dictTask = new DictionaryTask();
                        dictTask.TaskLoop();
                        break;
                    case 3:
                        var dllTask = new DoublyLinkedListTask();
                        dllTask.TaskLoop();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода.");
            }
        }
    }
}
