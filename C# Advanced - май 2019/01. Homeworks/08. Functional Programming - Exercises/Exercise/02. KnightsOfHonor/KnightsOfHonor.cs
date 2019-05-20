using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightsOfHonor
{
    public class KnightsOfHonor
    {
        private static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            names.ForEach(n => Console.WriteLine($"Sir {n}"));
        }
    }
}