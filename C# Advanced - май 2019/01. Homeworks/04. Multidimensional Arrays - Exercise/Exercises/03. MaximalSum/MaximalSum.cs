using System;
using System.Linq;

namespace _03.MaximalSum
{
    public class MaximalSum
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

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currentSum = matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row, col + 2]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1]
                        + matrix[row + 1, col + 2]
                        + matrix[row + 2, col]
                        + matrix[row + 2, col + 1]
                        + matrix[row + 2, col + 2];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");
            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}