using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SpaceStationEstablishment
{
    public class SpaceStationEstablishment
    {
        private static int rows;
        private static int cols;
        private static char[,] field;
        private static int playerRow;
        private static int playerCol;
        private static int firstHoleRow;
        private static int firstHoleCol;
        private static int secondHoleRow;
        private static int secondHoleCol;
        private static string command;
        private static bool isEnd;
        private static bool isOut;
        private static int points;

        private static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = rows;
            field = new char[rows, cols];
            FillField();

            command = Console.ReadLine();

            while (!isEnd && !isOut)
            {
                ExecuteCommand();

                if (!isEnd && !isOut)
                {
                    command = Console.ReadLine();
                }
            }

            if (isOut)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {points}");
            PrintField();
        }

        private static void ExecuteCommand()
        {
            switch (command)
            {
                case "up":
                    if (playerRow - 1 < 0)
                    {
                        OutOfTheField();
                    }
                    else
                    {
                        field[playerRow, playerCol] = '-';
                        playerRow--;

                        FindHallStarOrEmptyCell();
                    }
                    break;

                case "down":
                    if (playerRow + 1 > rows - 1)
                    {
                        OutOfTheField();
                    }
                    else
                    {
                        field[playerRow, playerCol] = '-';
                        playerRow++;

                        FindHallStarOrEmptyCell();
                    }
                    break;

                case "right":
                    if (playerCol + 1 > cols - 1)
                    {
                        OutOfTheField();
                    }
                    else
                    {
                        field[playerRow, playerCol] = '-';
                        playerCol++;

                        FindHallStarOrEmptyCell();
                    }
                    break;

                case "left":
                    if (playerCol - 1 < 0)
                    {
                        OutOfTheField();
                    }
                    else
                    {
                        field[playerRow, playerCol] = '-';
                        playerCol--;

                        FindHallStarOrEmptyCell();
                    }
                    break;

                default:
                    break;
            }
        }

        private static void FindHallStarOrEmptyCell()
        {
            if (field[playerRow, playerCol] == 'O')
            {
                FindHall();
            }
            else if (char.IsDigit(field[playerRow, playerCol]))
            {
                FindStar();
            }
            else if (field[playerRow, playerCol] == '-')
            {
                field[playerRow, playerCol] = 'S';
            }
        }

        private static void OutOfTheField()
        {
            isOut = true;
            field[playerRow, playerCol] = '-';
        }

        private static void FindStar()
        {
            points += int.Parse(field[playerRow, playerCol].ToString());
            field[playerRow, playerCol] = '-';

            if (points >= 50)
            {
                field[playerRow, playerCol] = 'S';
                isEnd = true;
            }
        }

        private static void FindHall()
        {
            field[firstHoleRow, firstHoleCol] = '-';
            field[secondHoleRow, secondHoleCol] = 'S';
            playerRow = secondHoleRow;
            playerCol = secondHoleCol;
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
            int hallsCount = 0;

            for (int row = 0; row < rows; row++)
            {
                List<char> currentRow = Console.ReadLine()
                    .ToCharArray()
                    .ToList();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = currentRow[col];

                    if (currentRow[col] == 'O' && hallsCount == 0)
                    {
                        firstHoleRow = row;
                        firstHoleCol = col;
                        hallsCount++;
                    }
                    else if (hallsCount == 1 && currentRow[col] == 'O')
                    {
                        secondHoleRow = row;
                        secondHoleCol = col;
                        hallsCount++;
                    }
                    else if (currentRow[col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}