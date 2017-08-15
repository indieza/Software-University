namespace _3.StudentsByAge
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class StudentsByAge
    {
        private static void Main()
        {
            Regex pattern = new Regex(@"(.*?)\s(\d+)");
            var students = new Dictionary<string, int>();

            string line = Console.ReadLine();

            while (!line.Equals("END"))
            {
                Match mat = pattern.Match(line);
                int age = int.Parse(mat.Groups[2].Value);

                if (age >= 18 && age <= 24)
                {
                    students.Add(mat.Groups[1].Value, age);
                }

                line = Console.ReadLine();
            }

            foreach (var item in students)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}