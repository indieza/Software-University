namespace _02.UpperStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class UpperStrings
    {
        private static void Main()
        {
            List<string> words = Console.ReadLine().Split().ToList();

            words.Select(word => word.ToUpper()).ToList().ForEach(word => Console.Write(word + " "));
        }
    }
}