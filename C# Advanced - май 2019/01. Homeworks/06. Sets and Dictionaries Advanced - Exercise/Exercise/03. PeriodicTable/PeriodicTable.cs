using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    public class PeriodicTable
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] items = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in items)
                {
                    elements.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(e => e)));
        }
    }
}