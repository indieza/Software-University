namespace _02.SquareWithMaximumSum
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class SquareWithMaximumSum
    {
        private static void Main()
        {
            int[] rowsCols = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[,] matrix = new int[rows, cols];

            int bestSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] +
                                     matrix[row + 1, col + 1];

                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            int maxSum = 0;

            for (int row = bestRow; row < bestRow + 2; row++)
            {
                for (int col = bestCol; col < bestCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                    maxSum += matrix[row, col];
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}