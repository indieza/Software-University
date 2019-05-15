using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    public class SumMatrixColumns
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

            int[] sumsCols = new int[cols];

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console
                .ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    sumsCols[col] += nums[col];
                }
            }
            Console.WriteLine(string.Join("\n", sumsCols));
        }
    }
}