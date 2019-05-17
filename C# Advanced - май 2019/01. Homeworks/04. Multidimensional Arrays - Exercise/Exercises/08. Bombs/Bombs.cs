using System;
using System.Linq;

namespace _08.Bombs
{
    public class Bombs
    {
        private static int[,] matrix;
        private static int n;

        private static void Main()
        {
            n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];

            FillMatrix();

            string[] cordinates = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var cordinate in cordinates)
            {
                int[] rowsCols = cordinate
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int bombRow = rowsCols[0];
                int bombCol = rowsCols[1];

                BombCells(bombRow, bombCol);
            }

            AliveCells();
            PrintMatrix();
        }

        private static void BombCells(int row, int col)
        {
            int damage = matrix[row, col];

            if (damage > 0)
            {
                BombCell(row - 1, col - 1, damage);
                BombCell(row - 1, col, damage);
                BombCell(row - 1, col + 1, damage);
                BombCell(row, col - 1, damage);
                BombCell(row, col + 1, damage);
                BombCell(row + 1, col - 1, damage);
                BombCell(row + 1, col, damage);
                BombCell(row + 1, col + 1, damage);
                matrix[row, col] = 0;
            }
        }

        private static void BombCell(int row, int col, int damage)
        {
            if (row >= 0 && row < n &&
                col >= 0 && col < n &&
                matrix[row, col] > 0)
            {
                matrix[row, col] -= damage;
            }
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < n; row++)
            {
                int[] items = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = items[col];
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void AliveCells()
        {
            int count = 0;
            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}