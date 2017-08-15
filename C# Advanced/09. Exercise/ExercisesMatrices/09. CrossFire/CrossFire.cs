namespace _09.CrossFire
{
    using System;
    using System.Linq;

    internal class CrossFire
    {
        private static void Main()
        {
            var rowsCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var rows = rowsCols[0];
            var cols = rowsCols[1];

            var matrix = new int[rows][];
            var count = 1;

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = count++;
                }
            }

            var inputLine = Console.ReadLine();

            while (inputLine != "Nuke it from orbit")
            {
                var arguments = inputLine.Split(' ').Select(int.Parse).ToArray();

                var row = arguments[0];
                var col = arguments[1];
                var radius = arguments[2];

                for (int i = row - radius; i <= row + radius; i++)
                {
                    if (IsInMatrix(matrix, i, col))
                    {
                        matrix[i][col] = -1;
                    }
                }

                for (int i = col - radius; i <= col + radius; i++)
                {
                    if (IsInMatrix(matrix, row, i))
                    {
                        matrix[row][i] = -1;
                    }
                }

                matrix = FilterMatrix(matrix);

                inputLine = Console.ReadLine();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                var line = string.Join(" ", matrix[i]);

                if (line.Length == 0)
                {
                    continue;
                }

                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static bool IsInMatrix(int[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static int[][] FilterMatrix(int[][] matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] < 0)
                    {
                        matrix[rowIndex] = matrix[rowIndex].Where(n => n != -1).ToArray();
                    }
                }

                if (matrix[rowIndex].Length < 1)
                {
                    matrix = matrix.Take(rowIndex).Concat(matrix.Skip(rowIndex + 1)).ToArray();
                    rowIndex--;
                }
            }

            return matrix;
        }
    }
}