using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._TriFunction
{
    public class Program
    {
        private static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                 .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string result = names.FirstOrDefault(n => n.ToCharArray().Select(c => (int)c).Sum() >= length);

            Console.WriteLine(result);
        }
    }
}