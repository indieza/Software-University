using System;
using System.Collections.Generic;

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
        private static int nikoladzeRow;
        private static int nikoladzeCol;
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
                    CheckIsSamAlive();

                    if (!isDied)
                    {
                        switch (direction)
                        {
                            case 'U':
                                field[samRow--, samCol] = '.';
                                field[samRow, samCol] = 'S';
                                CheckIsSamFindNikoladze();
                                break;

                            case 'D':
                                field[samRow++, samCol] = '.';
                                field[samRow, samCol] = 'S';
                                CheckIsSamFindNikoladze();
                                break;

                            case 'R':
                                field[samRow, samCol++] = '.';
                                field[samRow, samCol] = 'S';
                                CheckIsSamFindNikoladze();
                                break;

                            case 'L':
                                field[samRow, samCol--] = '.';
                                field[samRow, samCol] = 'S';
                                CheckIsSamFindNikoladze();
                                break;

                            case 'W':
                                CheckIsSamAlive();
                                break;

                            default:
                                break;
                        }
                    }
                }
            }

            PrintField();
        }

        private static void CheckIsSamFindNikoladze()
        {
            if (samRow == nikoladzeRow)
            {
                isDied = true;
                field[nikoladzeRow, nikoladzeCol] = 'X';
                Console.WriteLine("Nikoladze killed!");
            }
        }

        private static void PrintField()
        {
            for (int row = 0; row < rows; row++)
            {
                List<char> currentRow = new List<char>();

                for (int col = 0; col < cols; col++)
                {
                    currentRow.Add(field[row, col]);
                }

                Console.WriteLine(string.Join("", currentRow));
            }
        }

        private static void CheckIsSamAlive()
        {
            for (int col = 0; col < samCol; col++)
            {
                if (field[samRow, col] == 'b' && !isDied)
                {
                    SamDied();
                    break;
                }
            }
            for (int col = samCol; col < cols; col++)
            {
                if (field[samRow, col] == 'd' && !isDied)
                {
                    SamDied();
                    break;
                }
            }
        }

        private static void SamDied()
        {
            isDied = true;
            Console.WriteLine($"Sam died at {samRow}, {samCol}");
            field[samRow, samCol] = 'X';
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] == 'b')
                    {
                        if (col == cols - 1)
                        {
                            field[row, col] = 'd';
                        }
                        else
                        {
                            field[row, col] = '.';
                            field[row, col + 1] = 'b';
                            col++;
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
                            field[row, col] = '.';
                            field[row, col - 1] = 'd';
                        }
                    }
                }
            }
        }

        private static void FillTheField()
        {
            for (int col = 0; col < cols; col++)
            {
                CheckPlayersPossitions(0, col);

                field[0, col] = currentRow[col];
            }

            for (int row = 1; row < rows; row++)
            {
                currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    CheckPlayersPossitions(row, col);

                    field[row, col] = currentRow[col];
                }
            }
        }

        private static void CheckPlayersPossitions(int row, int col)
        {
            if (currentRow[col] == 'S')
            {
                samRow = row;
                samCol = col;
            }
            if (currentRow[col] == 'N')
            {
                nikoladzeRow = row;
                nikoladzeCol = col;
            }
        }
    }
}