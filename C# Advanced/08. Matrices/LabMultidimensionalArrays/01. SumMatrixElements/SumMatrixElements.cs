namespace _01.SumMatrixElements
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class SumMatrixElements
    {
        private static void Main()
        {
            int[] rowsCols = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int totalSum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Regex.Split(Console.ReadLine(), ", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    totalSum += numbers[col];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(totalSum);
        }
    }
}