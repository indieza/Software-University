namespace _03_Periodic_Table
{
    using System;
    using System.Collections.Generic;

    internal class PeriodicTable
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in input)
                {
                    elements.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}