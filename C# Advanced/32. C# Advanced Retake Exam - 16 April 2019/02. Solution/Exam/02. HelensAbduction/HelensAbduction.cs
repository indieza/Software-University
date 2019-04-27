using System;

namespace _02.HelensAbduction
{
    public class HelensAbduction
    {
        private static int parisEnergy;
        private static int rows;
        private static char[] line;
        private static int cols;
        private static int parisRow;
        private static int parisCol;
        private static char[,] matrix;
        private static bool end;

        private static void Main()
        {
            parisEnergy = int.Parse(Console.ReadLine());

            rows = int.Parse(Console.ReadLine());
            line = Console.ReadLine().ToCharArray();
            cols = line.Length;

            parisRow = 0;
            parisCol = 0;

            matrix = new char[rows, cols];

            FillMatrix();

            end = false;

            while (!end)
            {
                string[] commandItems = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string moveCommand = commandItems[0];
                int spawnRow = int.Parse(commandItems[1]);
                int spawnCol = int.Parse(commandItems[2]);

                matrix[spawnRow, spawnCol] = 'S';

                switch (moveCommand.ToLower())
                {
                    case "up":
                        if (parisRow - 1 < 0)
                        {
                            parisEnergy--;

                            if (parisEnergy <= 0)
                            {
                                ParisDie();
                            }
                        }
                        else
                        {
                            matrix[parisRow, parisCol] = '-';
                            parisRow--;
                            parisEnergy--;

                            if (parisEnergy <= 0)
                            {
                                ParisDie();
                            }
                            else
                            {
                                HelenaOrEnemy();
                            }
                        }
                        break;

                    case "down":
                        if (parisRow + 1 >= rows)
                        {
                            parisEnergy--;

                            if (parisEnergy <= 0)
                            {
                                ParisDie();
                            }
                        }
                        else
                        {
                            matrix[parisRow, parisCol] = '-';
                            parisRow++;
                            parisEnergy--;

                            if (parisEnergy <= 0)
                            {
                                ParisDie();
                            }
                            else
                            {
                                HelenaOrEnemy();
                            }
                        }
                        break;

                    case "left":
                        if (parisCol - 1 < 0)
                        {
                            parisEnergy--;

                            if (parisEnergy <= 0)
                            {
                                ParisDie();
                            }
                        }
                        else
                        {
                            matrix[parisRow, parisCol] = '-';
                            parisCol--;
                            parisEnergy--;

                            if (parisEnergy <= 0)
                            {
                                ParisDie();
                            }
                            else
                            {
                                HelenaOrEnemy();
                            }
                        }
                        break;

                    case "right":
                        if (parisCol + 1 >= cols)
                        {
                            parisEnergy--;

                            if (parisEnergy <= 0)
                            {
                                ParisDie();
                            }
                        }
                        else
                        {
                            matrix[parisRow, parisCol] = '-';
                            parisCol++;
                            parisEnergy--;

                            if (parisEnergy <= 0)
                            {
                                ParisDie();
                            }
                            else
                            {
                                HelenaOrEnemy();
                            }
                        }
                        break;

                    default:
                        break;
                }
            }

            PrintMatrix();
        }

        private static void HelenaOrEnemy()
        {
            if (matrix[parisRow, parisCol] == 'H')
            {
                FindHelena();
            }
            else if (matrix[parisRow, parisCol] == 'S')
            {
                parisEnergy -= 2;

                if (parisEnergy <= 0)
                {
                    ParisDie();
                }
                else
                {
                    matrix[parisRow, parisCol] = 'P';
                }
            }
        }

        private static void FindHelena()
        {
            end = true;
            matrix[parisRow, parisCol] = '-';
            Console.Write("Paris has successfully abducted Helen! ");
            Console.WriteLine($"Energy left: {parisEnergy}");
        }

        private static void ParisDie()
        {
            end = true;
            matrix[parisRow, parisCol] = 'X';
            Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrix()
        {
            for (int col = 0; col < cols; col++)
            {
                if (line[col] == 'P')
                {
                    parisRow = 0;
                    parisCol = col;
                }

                matrix[0, col] = line[col];
            }

            for (int row = 1; row < rows; row++)
            {
                line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    if (line[col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }

                    matrix[row, col] = line[col];
                }
            }
        }
    }
}