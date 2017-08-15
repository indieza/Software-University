namespace _01.TakeTwo
{
    using System;
    using System.Linq;

    internal class TakeTwo
    {
        private static void Main()
        {
            Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .Where(number => number >= 10 && number <= 20)
                .Distinct()
                .Take(2)
                .ToList()
                .ForEach(n => Console.Write(n + " "));
        }
    }
}