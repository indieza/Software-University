using System;
using System.Collections.Generic;
using System.Linq;

internal class CryptoMaster
{
    private static void Main()
    {
        List<int> sequance = Console.ReadLine()
            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        int max = 0;

        for (int i = 0; i < sequance.Count; i++)
        {
            for (int step = 1; step <= sequance.Count; step++)
            {
                int currentNumber = sequance[i];
                int indexOfNextNumber = (i + step) % sequance.Count;
                int nextNumber = sequance[indexOfNextNumber];
                int currentMax = 1;

                while (currentNumber < nextNumber)
                {
                    currentMax++;
                    int currentNumberIndex = indexOfNextNumber;
                    indexOfNextNumber = (currentNumberIndex + step) % sequance.Count;
                    currentNumber = nextNumber;
                    nextNumber = sequance[indexOfNextNumber];
                }

                if (max < currentMax)
                {
                    max = currentMax;
                }
            }
        }

        Console.WriteLine(max);
    }
}