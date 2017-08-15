namespace _1.StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class StudentsByGroup
    {
        private static void Main()
        {
            Regex pattern = new Regex(@"(.*?)\s(\d)");

            SortedSet<string> students = new SortedSet<string>();

            string line = Console.ReadLine();

            while (!line.Equals("END"))
            {
                Match mat = pattern.Match(line);
                string studName = mat.Groups[1].Value;
                int group = int.Parse(mat.Groups[2].Value);

                if (group == 2)
                {
                    students.Add(studName);
                }

                line = Console.ReadLine();
            }

            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
        }
    }
}