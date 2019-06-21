using System;
using System.Linq;

namespace ExamPreparation_20_June_2019
{
    public class StartUp
    {
        static int parisRow;
        static int parisCol;

        public static void Main()
        {
            //Read the input
            //  --Energy, fieldRows, field
            //Initialize matrix
            //While Paris alive and not won
            //  -Process turn
            //      --Spawn spartans
            //      --Move Paris
            //      --Check next Position
            //          #S -> Decrease energy
            //          #H -> Win the game
            //Print Output

            int energy = int.Parse(Console.ReadLine());
            int rowsCount = int.Parse(Console.ReadLine());

            char[][] field = new char[rowsCount][];

            InitializeMatrix(field);

            FindParisPosition(field);

            bool won = false;

            while (energy > 0)
            {
                string[] turn = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string moveDirection = turn[0];
                int spawnRow = int.Parse(turn[1]);
                int spawnCol = int.Parse(turn[2]);

                SpawnSpartans(field, spawnRow, spawnCol);

                field[parisRow][parisCol] = '-';

                MoveInDirection(field, moveDirection);
                energy--;

                char symbolOnNextStep = field[parisRow][parisCol];

                if (symbolOnNextStep == 'S')
                {
                    energy -= 2;
                    field[parisRow][parisCol] = 'P';
                }
                else if (symbolOnNextStep == 'H')
                {
                    won = true;
                    field[parisRow][parisCol] = '-';
                    break;
                }
                else if (symbolOnNextStep == '-')
                {
                    field[parisRow][parisCol] = 'P';
                }

                if (energy <= 0)
                {
                    field[parisRow][parisCol] = 'X';
                    break;
                }
            }

            PrintOutput(field, won, energy);
        }

        private static void PrintOutput(char[][] field, bool won, int energy)
        {
            if (won)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
            }
            else
            {
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }

            PrintMatrix(field);
        }

        private static void PrintMatrix(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                char[] currentRow = field[row];

                Console.WriteLine(String.Join("", currentRow));
            }
        }

        private static void MoveInDirection(char[][] field, string moveDirection)
        {
            if (moveDirection == "up")
            {
                if (parisRow - 1 >= 0)
                {
                    parisRow--;
                }
            }
            else if (moveDirection == "down")
            {
                if (parisRow + 1 < field.Length)
                {
                    parisRow++;
                }
            }
            else if (moveDirection == "left")
            {
                if (parisCol - 1 >= 0)
                {
                    parisCol--;
                }
            }
            else if (moveDirection == "right")
            {
                if (parisCol + 1 < field[parisRow].Length)
                {
                    parisCol++;
                }
            }
        }

        private static void SpawnSpartans(char[][] field, int spawnRow, int spawnCol)
        {
            field[spawnRow][spawnCol] = 'S';
        }

        private static void FindParisPosition(char[][] field)
        {
            bool found = false;

            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    char symbol = field[row][col];

                    if (symbol == 'P')
                    {
                        parisRow = row;
                        parisCol = col;

                        found = true;

                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }
        }

        private static void InitializeMatrix(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                field[row] = currentRow;
            }
        }
    }
}