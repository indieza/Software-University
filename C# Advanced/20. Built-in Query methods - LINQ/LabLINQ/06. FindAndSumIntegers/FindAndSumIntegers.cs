namespace _06.FindAndSumIntegers
{
    using System;
    using System.Linq;

    internal class FindAndSumIntegers
    {
        private static void Main()
        {
            long temp;

            var numbers = Console.ReadLine()
                .Split(' ')
                .Where(x => long.TryParse(x, out temp))
                .Select(long.Parse)
                .ToList();

            Console.WriteLine(numbers.Count == 0 ? "No match" : numbers.Sum().ToString());
        }
    }
}