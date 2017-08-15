namespace _04.MaximalSum
{
    using System;
    using System.Linq;

    internal class MaximalSum
    {
        private static void Main()
        {
            int[] rowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] numbers = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);
                }
            }

            int maxSum = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 1; row < rows - 1; row++)
            {
                for (int col = 1; col < cols - 1; col++)
                {
                    int currentSum = matrix[row - 1, col - 1] +
                                     matrix[row - 1, col] +
                                     matrix[row - 1, col + 1] +
                                     matrix[row, col - 1] +
                                     matrix[row, col] +
                                     matrix[row, col + 1] +
                                     matrix[row + 1, col - 1] +
                                     matrix[row + 1, col] +
                                     matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        bestRow = row - 1;
                        bestCol = col - 1;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = bestRow; row < bestRow + 3; row++)
            {
                for (int col = bestCol; col < bestCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}