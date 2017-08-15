namespace _7.ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ExcellentStudents
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            while (!line.Equals("END"))
            {
                string[] parts = line.Split(' ');
                string name = parts[0];
                string familyName = parts[1];
                List<int> mark = parts.Skip(2).Select(int.Parse).ToList();

                if (mark.Any(x => x == 6))
                {
                    Console.WriteLine(name + " " + familyName);
                }

                line = Console.ReadLine();
            }
        }
    }
}