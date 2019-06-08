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
        private static char[,] field;
        private static char[] currentRow;
        private static char[] directions;
        private static int samRow;
        private static int samCol;
        private static bool isDied;

        private static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            currentRow = Console.ReadLine().ToCharArray();
            cols = currentRow.Length;
            field = new char[rows, cols];
            isDied = false;

            FillTheField();

            directions = Console.ReadLine().ToCharArray();

            foreach (var direction in directions)
            {
                if (!isDied)
                {
                    MoveEnemies();

                    switch (direction)
                    {
                        case 'U':
                            break;

                        case 'D':
                            break;

                        case 'R':
                            break;

                        case 'L':
                            break;

                        case 'W':
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] == 'b')
                    {
                        if (col >= cols - 1)
                        {
                            field[row, col] = 'd';
                        }
                        else
                        {
                            field[row, col + 1] = 'b';
                            field[row, col] = '.';
                        }
                    }
                    else if (field[row, col] == 'd')
                    {
                        if (col == 0)
                        {
                            field[row, col] = 'b';
                        }
                        else
                        {
                            field[row, col - 1] = 'd';
                            field[row, col] = '.';
                        }
                    }
                }
            }
        }

        private static void FillTheField()
        {
            for (int col = 0; col < cols; col++)
            {
                if (field[0, col] == 'S')
                {
                    samRow = 0;
                    samCol = col;
                }

                field[0, col] = currentRow[col];
            }

            for (int row = 1; row < rows; row++)
            {
                currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }

                    field[row, col] = currentRow[col];
                }
            }
        }
    }
}