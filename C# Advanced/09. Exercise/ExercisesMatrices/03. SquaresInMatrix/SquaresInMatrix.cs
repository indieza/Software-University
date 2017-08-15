namespace _03.SquaresInMatrix
{
    using System;
    using System.Linq;

    internal class SquaresInMatrix
    {
        private static void Main()
        {
            int[] rowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = char.Parse(line[col]);
                }
            }

            int counter = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row + 1, col] == matrix[row + 1, col + 1] &&
                        matrix[row + 1, col + 1] == matrix[row, col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}