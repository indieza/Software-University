using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    public class SquareWithMaximumSum
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
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console
                .ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            int sum = 0;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currentSum = matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[startRow, startCol]} {matrix[startRow, startCol + 1]}");
            Console.WriteLine($"{matrix[startRow + 1, startCol]} {matrix[startRow + 1, startCol + 1]}");
            Console.WriteLine(sum);
        }
    }
}