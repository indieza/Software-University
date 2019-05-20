using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    public class FilterByAge
    {
        private static void Main()
        {
            Dictionary<string, int> students = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] items = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                string currentName = items[0];
                int currentAge = int.Parse(items[1]);

                students.Add(currentName, currentAge);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split();

            if (condition == "older")
            {
                students = students.Where(s => s.Value >= age).ToDictionary(k => k.Key, v => v.Value);

                PrintFormat(students, format);
            }
            else if (condition == "younger")
            {
                students = students.Where(s => s.Value < age).ToDictionary(k => k.Key, v => v.Value);

                PrintFormat(students, format);
            }
        }

        private static void PrintFormat(Dictionary<string, int> students, string[] format)
        {
            if (format.Length == 2)
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Key} - {student.Value}");
                }
            }
            else
            {
                if (format[0] == "age")
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Value}");
                    }
                }
                else
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Key}");
                    }
                }
            }
        }
    }
}