using System;
using System.Linq;

namespace _05.SnakeMoves
{
    public class SnakeMoves
    {
        private static void Main()
        {
            int[] rowsCols = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            char[] word = Console.ReadLine().ToCharArray();
            int count = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (count == word.Length)
                    {
                        count = 0;
                    }

                    Console.Write($"{word[count]}");
                    count++;
                }

                Console.WriteLine();
            }
        }
    }
}