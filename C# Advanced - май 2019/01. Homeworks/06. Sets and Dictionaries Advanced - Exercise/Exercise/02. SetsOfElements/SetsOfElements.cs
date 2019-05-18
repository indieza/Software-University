using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    public class SetsOfElements
    {
        private static void Main()
        {
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            int[] setsLength = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = setsLength[0];
            int m = setsLength[1];

            for (int i = 0; i < n; i++)
            {
                first.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }

            first.IntersectWith(second);

            Console.WriteLine(string.Join(" ", first));
        }
    }
}