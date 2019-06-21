using System;

namespace _02.HelenAbduction
{
    public class HelenAbduction
    {
        private static int parisEnergy;
        private static int rows;
        private static char[][] field;
        private static int parisRow;
        private static int parisCol;
        private static int spawnRow;
        private static int spawnCol;
        private static string[] commandItems;
        private static bool isEnd;

        private static void Main()
        {
            parisEnergy = int.Parse(Console.ReadLine());
            rows = int.Parse(Console.ReadLine());
            field = new char[rows][];

            FillField();

            while (!isEnd)
            {
                commandItems = Console.ReadLine().Split();
                ExecuteCommand();
            }

            PrintField();
        }

        private static void ExecuteCommand()
        {
            switch (commandItems[0])
            {
                case "up":
                    TakeSpawnCordinates();
                    PutSpawnsOnField();

                    if (parisRow - 1 < 0)
                    {
                        parisEnergy--;
                        IsParisAlive();
                    }
                    else
                    {
                        field[parisRow][parisCol] = '-';
                        parisRow--;
                        FindHelenaEnemyOrEmptyCell();
                    }
                    break;

                case "down":
                    TakeSpawnCordinates();
                    PutSpawnsOnField();

                    if (parisRow + 1 > rows - 1)
                    {
                        parisEnergy--;
                        IsParisAlive();
                    }
                    else
                    {
                        field[parisRow][parisCol] = '-';
                        parisRow++;
                        FindHelenaEnemyOrEmptyCell();
                    }
                    break;

                case "left":
                    TakeSpawnCordinates();
                    PutSpawnsOnField();
                    if (parisCol - 1 < 0)
                    {
                        parisEnergy--;
                        IsParisAlive();
                    }
                    else
                    {
                        field[parisRow][parisCol] = '-';
                        parisCol--;
                        FindHelenaEnemyOrEmptyCell();
                    }
                    break;

                case "right":
                    TakeSpawnCordinates();
                    PutSpawnsOnField();
                    if (parisCol + 1 > field[0].Length - 1)
                    {
                        parisEnergy--;
                        IsParisAlive();
                    }
                    else
                    {
                        field[parisRow][parisCol] = '-';
                        parisCol++;
                        FindHelenaEnemyOrEmptyCell();
                    }
                    break;

                default:
                    break;
            }
        }

        private static void FindHelenaEnemyOrEmptyCell()
        {
            if (field[parisRow][parisCol] == '-')
            {
                field[parisRow][parisCol] = 'P';
                parisEnergy--;
                IsParisAlive();
            }
            else if (field[parisRow][parisCol] == 'H')
            {
                isEnd = true;
                parisEnergy--;
                field[parisRow][parisCol] = '-';
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
            }
            else if (field[parisRow][parisCol] == 'S')
            {
                parisEnergy--;
                parisEnergy -= 2;
                IsParisAlive();

                if (!isEnd)
                {
                    field[parisRow][parisCol] = 'P';
                }
            }
        }

        private static void IsParisAlive()
        {
            if (parisEnergy <= 0)
            {
                isEnd = true;
                field[parisRow][parisCol] = 'X';
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }
        }

        private static void PutSpawnsOnField()
        {
            field[spawnRow][spawnCol] = 'S';
        }

        private static void TakeSpawnCordinates()
        {
            spawnRow = int.Parse(commandItems[1]);
            spawnCol = int.Parse(commandItems[2]);
        }

        private static void PrintField()
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }

        private static void FillField()
        {
            for (int row = 0; row < rows; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }
        }
    }
}