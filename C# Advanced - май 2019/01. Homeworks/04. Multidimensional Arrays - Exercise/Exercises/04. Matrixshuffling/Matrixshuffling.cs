using System;
using System.Linq;

namespace _04.Matrixshuffling
{
    public class Matrixshuffling
    {
        private static void Main()
        {
            int[] rowsCols = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] items = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = items[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] items = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (!items.Contains("swap") || items.Length < 5 || items.Length > 5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                int startRow = int.Parse(items[1]);
                int startCol = int.Parse(items[2]);
                int endRow = int.Parse(items[3]);
                int endCol = int.Parse(items[4]);

                if (startRow >= 0 && startRow < rows && endCol >= 0 && endCol < cols)
                {
                    string save = matrix[endRow, endCol];
                    matrix[endRow, endCol] = matrix[startRow, startCol];
                    matrix[startRow, startCol] = save;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }
    }
}