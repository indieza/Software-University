using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    public class AverageStudentGrades
    {
        private static void Main()
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] items = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = items[0];
                double mark = double.Parse(items[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }

                students[name].Add(mark);
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var mark in student.Value)
                {
                    Console.Write($"{mark:F2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Sum() / student.Value.Count():F2})");
            }
        }
    }
}