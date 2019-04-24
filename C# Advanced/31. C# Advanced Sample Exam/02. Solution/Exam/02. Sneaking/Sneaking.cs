using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sneaking
{
    public class Sneaking
    {
        private static int rows;
        private static int cols;
        private static char[,] matrix;
        private static char[] line;

        private static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            line = Console.ReadLine().ToCharArray();
            cols = line.Length;
            matrix = new char[rows, cols];

            FillMatrix();
        }

        private static void FillMatrix()
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[0, col] = line[col];
            }

            for (int row = 0; row < rows - 1; row++)
            {
                line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }
    }
}