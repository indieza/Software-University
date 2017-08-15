namespace _06.TargetPractice
{
    using System;

    internal class TargetPractice
    {
        private static void Main()
        {
            string[] martixRowCol = Console.ReadLine().Split();

            int rows = int.Parse(martixRowCol[0]);
            int cols = int.Parse(martixRowCol[1]);

            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            FillMatrix(snake, matrix, rows, cols);

            string[] shotArguments = Console.ReadLine().Split(' ');

            int impactRow = int.Parse(shotArguments[0]);
            int impactCol = int.Parse(shotArguments[1]);
            int radius = int.Parse(shotArguments[2]);

            FireAShot(matrix, impactRow, impactCol, radius);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                RunGravity(matrix, col);
            }

            PrintMatrix(matrix);
        }

        private static void RunGravity(char[,] matrix, int col)
        {
            while (true)
            {
                bool hasFallen = false;

                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    char currentChar = matrix[row, col];
                    char topChar = matrix[row - 1, col];

                    if (currentChar == ' ' && topChar != ' ')
                    {
                        matrix[row, col] = topChar;
                        matrix[row - 1, col] = ' ';
                        hasFallen = true;
                    }
                }

                if (!hasFallen)
                {
                    break;
                }
            }
        }

        private static void FireAShot(char[,] matrix, int impactRow, int impactCol, int radius)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (Math.Pow(col - impactCol, 2) + Math.Pow(row - impactRow, 2) <= radius * radius)
                    {
                        matrix[row, col] = ' ';
                    }
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

        private static void FillMatrix(string snake, char[,] matrix, int rows, int cols)
        {
            bool isPrintLeft = true;
            int currentIndex = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                if (isPrintLeft)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (currentIndex >= snake.Length)
                        {
                            currentIndex = 0;
                        }

                        matrix[row, col] = snake[currentIndex];
                        currentIndex++;
                    }
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (currentIndex >= snake.Length)
                        {
                            currentIndex = 0;
                        }

                        matrix[row, col] = snake[currentIndex];
                        currentIndex++;
                    }
                }

                isPrintLeft = !isPrintLeft;
            }
        }
    }
}