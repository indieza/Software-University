using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ActionPoint
{
    public class ActionPoint
    {
        private static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            names.ForEach(n => Console.WriteLine(n));
        }
    }
}