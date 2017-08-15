namespace _02.DiagonalDifference
{
    using System;

    internal class DiagonalDifference
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int[,] matrix = new int[number, number];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] numbers = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);
                }
            }

            int rightDiagonal = 0;
            int leftDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                rightDiagonal += matrix[row, row];
                leftDiagonal += matrix[row, (matrix.GetLength(0) - row) - 1];
            }

            Console.WriteLine(Math.Abs(rightDiagonal - leftDiagonal));
        }
    }
}