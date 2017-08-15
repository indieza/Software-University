namespace AddVAT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class AddVAT
    {
        private static void Main()
        {
            List<double> input = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToList();

            input.ForEach(n => Console.WriteLine($"{n:F2}"));
        }
    }
}