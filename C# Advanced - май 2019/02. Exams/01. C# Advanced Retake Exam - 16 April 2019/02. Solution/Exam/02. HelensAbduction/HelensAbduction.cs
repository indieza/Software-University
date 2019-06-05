using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.HelensAbduction
{
    public class HelensAbduction
    {
        private static int parisEnergy;
        private static int rows;
        private static int cols;
        private static char[] currentRow;
        private static char[,] field;
        private static string[] commandItems;
        private static string command;
        private static int targetRow;
        private static int targetCol;
        private static int parisRow;
        private static int parisCol;
        private static bool isEnd;

        private static void Main()
        {
            parisEnergy = int.Parse(Console.ReadLine());
            rows = int.Parse(Console.ReadLine());
            currentRow = Console.ReadLine().ToCharArray();
            cols = currentRow.Count();

            field = new char[rows, cols];
            isEnd = false;

            FillFiled();

            while (!isEnd)
            {
                ExecuteCommandParameters();
                field[targetRow, targetCol] = 'S';

                ProcessingCommand();
            }

            PrintField();
        }

        private static void ProcessingCommand()
        {
            switch (command.ToLower())
            {
                case "up":
                    if (parisRow - 1 < 0)
                    {
                        DecreaseParisEnegry();
                    }
                    else
                    {
                        field[parisRow, parisCol] = '-';
                        parisRow--;
                        DecreaseParisEnegry();

                        if (!isEnd)
                        {
                            ParisFindHelenaOrEnemy();
                        }
                    }
                    break;

                case "down":
                    if (parisRow + 1 >= rows)
                    {
                        DecreaseParisEnegry();
                    }
                    else
                    {
                        field[parisRow, parisCol] = '-';
                        parisRow++;
                        DecreaseParisEnegry();

                        if (!isEnd)
                        {
                            ParisFindHelenaOrEnemy();
                        }
                    }
                    break;

                case "left":
                    if (parisCol - 1 < 0)
                    {
                        DecreaseParisEnegry();
                    }
                    else
                    {
                        field[parisRow, parisCol] = '-';
                        parisCol--;
                        DecreaseParisEnegry();

                        if (!isEnd)
                        {
                            ParisFindHelenaOrEnemy();
                        }
                    }
                    break;

                case "right":
                    if (parisCol + 1 >= cols)
                    {
                        DecreaseParisEnegry();
                    }
                    else
                    {
                        field[parisRow, parisCol] = '-';
                        parisCol++;
                        DecreaseParisEnegry();

                        if (!isEnd)
                        {
                            ParisFindHelenaOrEnemy();
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private static void DecreaseParisEnegry()
        {
            parisEnergy--;

            if (parisEnergy <= 0)
            {
                ParisDie();
            }
        }

        private static void ParisFindHelenaOrEnemy()
        {
            if (field[parisRow, parisCol] == 'S')
            {
                parisEnergy -= 2;

                if (parisEnergy <= 0)
                {
                    ParisDie();
                }
                else
                {
                    field[parisRow, parisCol] = 'P';
                }
            }
            else if (field[parisRow, parisCol] == 'H')
            {
                ParisFindHelena();
            }
            else
            {
                field[parisRow, parisCol] = 'P';
            }
        }

        private static void ParisFindHelena()
        {
            isEnd = true;
            field[parisRow, parisCol] = '-';
            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
        }

        private static void ParisDie()
        {
            isEnd = true;
            field[parisRow, parisCol] = 'X';
            Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
        }

        private static void ExecuteCommandParameters()
        {
            commandItems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            command = commandItems[0];
            targetRow = int.Parse(commandItems[1]);
            targetCol = int.Parse(commandItems[2]);
        }

        private static void FillFiled()
        {
            for (int col = 0; col < cols; col++)
            {
                if (currentRow[col] == 'P')
                {
                    parisRow = 0;
                    parisCol = col;
                }

                field[0, col] = currentRow[col];
            }

            for (int row = 1; row < rows; row++)
            {
                currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    if (currentRow[col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }

                    field[row, col] = currentRow[col];
                }
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
    }
}