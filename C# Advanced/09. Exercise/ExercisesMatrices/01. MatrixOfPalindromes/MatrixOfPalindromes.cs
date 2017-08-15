namespace _01.MatrixOfPalindromes
{
    using System;
    using System.Linq;

    internal class MatrixOfPalindromes
    {
        private static void Main()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = numbers[0];
            int cols = numbers[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = alphabet[row] + alphabet[row + col].ToString() + alphabet[row];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}