namespace _04.PascalTriangle
{
    using System;

    internal class PascalTriangle
    {
        private static void Main()
        {
            int height = int.Parse(Console.ReadLine());

            long[][] triangle = new long[height + 1][];

            for (int row = 0; row < height; row++)
            {
                triangle[row] = new long[row + 1];
            }

            triangle[0][0] = 1;

            for (int row = 0; row < height - 1; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    triangle[row + 1][col] += triangle[row][col];
                    triangle[row + 1][col + 1] += triangle[row][col];
                }
            }

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    Console.Write("{0} ", triangle[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}