using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    public class PredicateForNames
    {
        private static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Console.WriteLine(string.Join("\n", names.Where(n => n.Length <= length)));
        }
    }
}