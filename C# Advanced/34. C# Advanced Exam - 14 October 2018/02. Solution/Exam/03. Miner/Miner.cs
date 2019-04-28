using System;

namespace _03.Miner
{
    public class Miner
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();

            char[,] matrix = new char[n, n];
            int coals = 0;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < n; row++)
            {
                string[] symbols = Console.ReadLine().Split();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = char.Parse(symbols[col]);

                    if (char.Parse(symbols[col]) == 'c')
                    {
                        coals++;
                    }

                    if (char.Parse(symbols[col]) == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            bool endGame = false;

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];

                switch (currentCommand)
                {
                    case "up":
                        if (startRow - 1 >= 0)
                        {
                            if (matrix[startRow - 1, startCol] == 'c')
                            {
                                matrix[startRow - 1, startCol] = '*';
                                coals--;
                                startRow -= 1;
                            }
                            else if (matrix[startRow - 1, startCol] == 'e')
                            {
                                startRow -= 1;
                                endGame = true;
                            }
                            else
                            {
                                startRow -= 1;
                            }
                        }

                        break;

                    case "down":
                        if (startRow + 1 <= n - 1)
                        {
                            if (matrix[startRow + 1, startCol] == 'c')
                            {
                                matrix[startRow + 1, startCol] = '*';
                                coals--;
                                startRow += 1;
                            }
                            else if (matrix[startRow + 1, startCol] == 'e')
                            {
                                startRow += 1;
                                endGame = true;
                            }
                            else
                            {
                                startRow += 1;
                            }
                        }

                        break;

                    case "left":
                        if (startCol - 1 >= 0)
                        {
                            if (matrix[startRow, startCol - 1] == 'c')
                            {
                                matrix[startRow, startCol - 1] = '*';
                                coals--;
                                startCol -= 1;
                            }
                            else if (matrix[startRow, startCol - 1] == 'e')
                            {
                                startCol -= 1;
                                endGame = true;
                            }
                            else
                            {
                                startCol -= 1;
                            }
                        }

                        break;

                    case "right":
                        if (startCol + 1 <= n - 1)
                        {
                            if (matrix[startRow, startCol + 1] == 'c')
                            {
                                matrix[startRow, startCol + 1] = '*';
                                coals--;
                                startCol += 1;
                            }
                            else if (matrix[startRow, startCol + 1] == 'e')
                            {
                                startCol += 1;
                                endGame = true;
                            }
                            else
                            {
                                startCol += 1;
                            }
                        }

                        break;

                    default:
                        break;
                }

                if (coals == 0 || endGame)
                {
                    break;
                }
            }

            if (coals == 0)
            {
                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
            }
            else if (endGame)
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
            }
            else
            {
                Console.WriteLine($"{coals} coals left. ({startRow}, {startCol})");
            }
        }
    }
}