using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TronRacers
{
    public class TronRacers
    {
        private static int rows;
        private static int cols;
        private static char[,] field;
        private static string[] commandItems;
        private static string firstPlayerCommand;
        private static string secondPlayerCommand;
        private static int firstPlayerRow;
        private static int firstPlayerCol;
        private static int secondPlayerRow;
        private static int secondPlayerCol;
        private static bool isDead;

        private static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = rows;
            field = new char[rows, cols];

            FillField();

            while (!isDead)
            {
                commandItems = Console.ReadLine().Split();
                firstPlayerCommand = commandItems[0];
                secondPlayerCommand = commandItems[1];
                FirstPlayerMakeMove(firstPlayerCommand);
                if (!isDead)
                {
                    SecondPlayerMakeMove(secondPlayerCommand);
                }
            }

            PrintField();
        }

        private static void SecondPlayerMakeMove(string command)
        {
            switch (command)
            {
                case "down":
                    if (secondPlayerRow + 1 > rows - 1)
                    {
                        secondPlayerRow = 0;
                    }
                    else
                    {
                        secondPlayerRow++;
                    }

                    if (field[secondPlayerRow, secondPlayerCol] == 'f')
                    {
                        isDead = true;
                        field[secondPlayerRow, secondPlayerCol] = 'x';
                    }
                    else
                    {
                        field[secondPlayerRow, secondPlayerCol] = 's';
                    }
                    break;

                case "up":
                    if (secondPlayerRow - 1 < 0)
                    {
                        secondPlayerRow = rows - 1;
                    }
                    else
                    {
                        secondPlayerRow--;
                    }

                    if (field[secondPlayerRow, secondPlayerCol] == 'f')
                    {
                        isDead = true;
                        field[secondPlayerRow, secondPlayerCol] = 'x';
                    }
                    else
                    {
                        field[secondPlayerRow, secondPlayerCol] = 's';
                    }
                    break;

                case "left":
                    if (secondPlayerCol - 1 < 0)
                    {
                        secondPlayerCol = cols - 1;
                    }
                    else
                    {
                        secondPlayerCol--;
                    }

                    if (field[secondPlayerRow, secondPlayerCol] == 'f')
                    {
                        isDead = true;
                        field[secondPlayerRow, secondPlayerCol] = 'x';
                    }
                    else
                    {
                        field[secondPlayerRow, secondPlayerCol] = 's';
                    }
                    break;

                case "right":
                    if (secondPlayerCol + 1 > cols - 1)
                    {
                        secondPlayerCol = 0;
                    }
                    else
                    {
                        secondPlayerCol++;
                    }

                    if (field[secondPlayerRow, secondPlayerCol] == 'f')
                    {
                        isDead = true;
                        field[secondPlayerRow, secondPlayerCol] = 'x';
                    }
                    else
                    {
                        field[secondPlayerRow, secondPlayerCol] = 's';
                    }
                    break;

                default:
                    break;
            }
        }

        private static void FirstPlayerMakeMove(string command)
        {
            switch (command)
            {
                case "down":
                    if (firstPlayerRow + 1 > rows - 1)
                    {
                        firstPlayerRow = 0;
                    }
                    else
                    {
                        firstPlayerRow++;
                    }

                    if (field[firstPlayerRow, firstPlayerCol] == 's')
                    {
                        isDead = true;
                        field[firstPlayerRow, firstPlayerCol] = 'x';
                    }
                    else
                    {
                        field[firstPlayerRow, firstPlayerCol] = 'f';
                    }
                    break;

                case "up":
                    if (firstPlayerRow - 1 < 0)
                    {
                        firstPlayerRow = rows - 1;
                    }
                    else
                    {
                        firstPlayerRow--;
                    }

                    if (field[firstPlayerRow, firstPlayerCol] == 's')
                    {
                        isDead = true;
                        field[firstPlayerRow, firstPlayerCol] = 'x';
                    }
                    else
                    {
                        field[firstPlayerRow, firstPlayerCol] = 'f';
                    }
                    break;

                case "left":
                    if (firstPlayerCol - 1 < 0)
                    {
                        firstPlayerCol = cols - 1;
                    }
                    else
                    {
                        firstPlayerCol--;
                    }

                    if (field[firstPlayerRow, firstPlayerCol] == 's')
                    {
                        isDead = true;
                        field[firstPlayerRow, firstPlayerCol] = 'x';
                    }
                    else
                    {
                        field[firstPlayerRow, firstPlayerCol] = 'f';
                    }
                    break;

                case "right":
                    if (firstPlayerCol + 1 > cols - 1)
                    {
                        firstPlayerCol = 0;
                    }
                    else
                    {
                        firstPlayerCol++;
                    }

                    if (field[firstPlayerRow, firstPlayerCol] == 's')
                    {
                        isDead = true;
                        field[firstPlayerRow, firstPlayerCol] = 'x';
                    }
                    else
                    {
                        field[firstPlayerRow, firstPlayerCol] = 'f';
                    }
                    break;

                default:
                    break;
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

        private static void FillField()
        {
            for (int row = 0; row < rows; row++)
            {
                List<char> currentRow = Console.ReadLine()
                    .ToCharArray()
                    .ToList();

                for (int col = 0; col < cols; col++)
                {
                    if (currentRow[col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                    if (currentRow[col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    field[row, col] = currentRow[col];
                }
            }
        }
    }
}