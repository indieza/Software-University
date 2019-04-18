using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TronRacers
{
    public class TronRacers
    {
        private static int firstPlayerRow = 0;
        private static int firstPlayerCol = 0;
        private static int secondPlayerRow = 0;
        private static int secondPlayerCol = 0;
        private static int n = 0;
        private static char[,] matrix = new char[0, 0];
        private static bool end = false;
        private static void Main()
        {
            n = int.Parse(Console.ReadLine());

            matrix = new char[n, n];


            FillMatrix();

            while (!end)
            {
                string[] commands = Console.ReadLine().Split();
                string firstPlayerCommand = commands[0];
                string secondPlayerCommand = commands[1];

                switch (firstPlayerCommand)
                {
                    case "up":
                        if (firstPlayerRow == 0)
                        {
                            firstPlayerRow = n - 1;
                            CheckNextPossitionForFirstPlayer();
                        }
                        else
                        {
                            firstPlayerRow--;
                            CheckNextPossitionForFirstPlayer();
                        }
                        break;
                    case "down":
                        if (firstPlayerRow == n - 1)
                        {
                            firstPlayerRow = 0;
                            CheckNextPossitionForFirstPlayer();
                        }
                        else
                        {
                            firstPlayerRow++;
                            CheckNextPossitionForFirstPlayer();
                        }
                        break;
                    case "left":
                        if (firstPlayerCol == 0)
                        {
                            firstPlayerCol = n - 1;
                            CheckNextPossitionForFirstPlayer();
                        }
                        else
                        {
                            firstPlayerCol--;
                            CheckNextPossitionForFirstPlayer();
                        }
                        break;
                    case "right":
                        if (firstPlayerCol == n - 1)
                        {
                            firstPlayerCol = 0;
                            CheckNextPossitionForFirstPlayer();
                        }
                        else
                        {
                            firstPlayerCol++;
                            CheckNextPossitionForFirstPlayer();
                        }
                        break;
                    default:
                        break;
                }
                if (!end)
                {
                    switch (secondPlayerCommand)
                    {
                        case "up":
                            if (secondPlayerRow == 0)
                            {
                                secondPlayerRow = n - 1;
                                CheckNextPossitionForSecondPlayer();
                            }
                            else
                            {
                                secondPlayerRow--;
                                CheckNextPossitionForSecondPlayer();
                            }
                            break;
                        case "down":
                            if (secondPlayerRow == n - 1)
                            {
                                secondPlayerRow = 0;
                                CheckNextPossitionForSecondPlayer();
                            }
                            else
                            {
                                secondPlayerRow++;
                                CheckNextPossitionForSecondPlayer();
                            }
                            break;
                        case "left":
                            if (secondPlayerCol == 0)
                            {
                                secondPlayerCol = n - 1;
                                CheckNextPossitionForSecondPlayer();
                            }
                            else
                            {
                                secondPlayerCol--;
                                CheckNextPossitionForSecondPlayer();
                            }
                            break;
                        case "right":
                            if (secondPlayerCol == n - 1)
                            {
                                secondPlayerCol = 0;
                                CheckNextPossitionForSecondPlayer();
                            }
                            else
                            {
                                secondPlayerCol++;
                                CheckNextPossitionForSecondPlayer();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void CheckNextPossitionForSecondPlayer()
        {
            if (matrix[secondPlayerRow, secondPlayerCol] == 'f')
            {
                end = true;
                matrix[secondPlayerRow, secondPlayerCol] = 'x';
            }
            else
            {
                matrix[secondPlayerRow, secondPlayerCol] = 's';
            }
        }

        private static void CheckNextPossitionForFirstPlayer()
        {
            if (matrix[firstPlayerRow, firstPlayerCol] == 's')
            {
                end = true;
                matrix[firstPlayerRow, firstPlayerCol] = 'x';
            }
            else
            {
                matrix[firstPlayerRow, firstPlayerCol] = 'f';
            }
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < n; row++)
            {
                char[] items = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    if (items[col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (items[col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }

                    matrix[row, col] = items[col];
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
