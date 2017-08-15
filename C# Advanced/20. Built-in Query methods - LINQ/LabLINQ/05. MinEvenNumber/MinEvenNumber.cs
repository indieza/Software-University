namespace _05.MinEvenNumber
{
    using System;
    using System.Linq;

    internal class MinEvenNumber
    {
        private static void Main()
        {
            var evenNumbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .Where(number => number % 2 == 0)
                .ToList();

            Console.WriteLine(evenNumbers.Count == 0 ? "No match" : $"{evenNumbers.Min():F2}");
        }
    }
}