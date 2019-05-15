using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    public class SumMatrixElements
    {
        private static void Main()
        {
            int[] rowsCols = Console
                .ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console
                .ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    sum += nums[col];
                }
            }
            Console.WriteLine($"{rows}\n{cols}\n{sum}");
        }
    }
}