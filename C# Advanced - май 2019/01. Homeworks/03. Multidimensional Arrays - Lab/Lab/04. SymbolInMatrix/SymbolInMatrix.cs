using System;

namespace _04.SymbolInMatrix
{
    public class SymbolInMatrix
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] symbols = Console
                .ReadLine()
                .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            char searchSymbol = char.Parse(Console.ReadLine());
            int symbolRow = -1;
            int symbolCol = -1;
            bool isFind = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == searchSymbol)
                    {
                        symbolRow = row;
                        symbolCol = col;
                        isFind = true;
                        break;
                    }
                }
                if (isFind)
                {
                    break;
                }
            }

            if (isFind)
            {
                Console.WriteLine($"({symbolRow}, {symbolCol})");
            }
            else
            {
                Console.WriteLine($"{searchSymbol} does not occur in the matrix");
            }
        }
    }
}