namespace _03.FirstName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class FirstName
    {
        private static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split(' ')
                .ToList();

            char[] letters = Console.ReadLine()
                .Split(' ')
                .Select(x => char.ToUpper(char.Parse(x)))
                .ToArray();

            var result = names
                .Where(name => Array.IndexOf(letters, char.ToUpper(name[0])) >= 0)
                .OrderBy(x => x)
                .FirstOrDefault();

            Console.WriteLine(result ?? "No match");
        }
    }
}