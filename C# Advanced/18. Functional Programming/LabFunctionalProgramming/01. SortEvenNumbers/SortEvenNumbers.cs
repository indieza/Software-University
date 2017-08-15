namespace _01.SortEvenNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SortEvenNumbers
    {
        private static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).Where(n => n % 2 == 0).OrderBy(n => n).ToList();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}