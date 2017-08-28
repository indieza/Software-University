using System;
using System.Collections.Generic;
using System.Linq;

internal class CubicsRube
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string line = Console.ReadLine();

        long sum = 0;
        int count = 0;

        while (line != "Analyze")
        {
            int[] items = line.Split().Select(int.Parse).ToArray();

            List<int> dimensions = new List<int>(items.Take(3));

            if (dimensions.Any(p => p < 0 || p > n))
            {
                line = Console.ReadLine();
                continue;
            }

            int particles = items[3];

            if (particles != 0)
            {
                sum += particles;
                count++;
            }

            line = Console.ReadLine();
        }

        Console.WriteLine(sum);
        Console.WriteLine(Math.Pow(n, 3) - count);
    }
}