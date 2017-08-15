namespace _8.WeakStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class WeakStudents
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

                List<int> weak = mark.Where(x => x <= 3).ToList();

                if (weak.Count >= 2)
                {
                    Console.WriteLine(name + " " + familyName);
                }

                line = Console.ReadLine();
            }
        }
    }
}