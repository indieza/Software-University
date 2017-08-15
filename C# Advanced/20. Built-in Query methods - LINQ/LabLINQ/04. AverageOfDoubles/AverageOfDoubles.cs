namespace _04.AverageOfDoubles
{
    using System;
    using System.Linq;

    internal class AverageOfDoubles
    {
        private static void Main()
        {
            var result = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .Average();

            Console.WriteLine($"{result:F2}");
        }
    }
}