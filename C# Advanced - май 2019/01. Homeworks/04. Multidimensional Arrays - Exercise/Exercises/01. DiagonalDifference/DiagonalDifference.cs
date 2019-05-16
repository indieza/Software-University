using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    public class DiagonalDifference
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int leftDiagonal = 0;
            int rightDiagonal = 0;

            for (int row = 0; row < n; row++)
            {
                int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < n; col++)
                {
                    if (row == col)
                    {
                        rightDiagonal += numbers[col];
                    }
                    if (row + col == n - 1)
                    {
                        leftDiagonal += numbers[col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(rightDiagonal - leftDiagonal));
        }
    }
}