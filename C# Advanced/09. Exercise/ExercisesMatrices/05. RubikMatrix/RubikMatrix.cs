namespace _05.RubikMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RubikMatrix
    {
        private static int[][] matrix = new int[1][];
        private static int rows;
        private static int cols;

        private static void Main()
        {
            var matrixDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            rows = matrixDimensions[0];
            cols = matrixDimensions[1];
            InitMatrix(rows, cols);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(' ').ToArray();
                var lineNumber = int.Parse(command[0]);
                var direction = command[1];
                var moves = long.Parse(command[2]);

                switch (direction)
                {
                    case "up":
                    case "down":
                        MoveUpOrDown(lineNumber, moves, direction);
                        break;

                    case "left":
                    case "right":
                        MoveLeftOrRight(lineNumber, moves, direction);
                        break;
                }
            }

            RearrangeMatrix();
        }

        private static void InitMatrix(int rows, int cols)
        {
            matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = i * cols + j + 1;
                }
            }
        }

        private static void MoveUpOrDown(int line, long moves, string direction)
        {
            int m = (int)(moves % cols);

            var colValues = new Queue<int>();

            if (direction == "down")
            {
                for (int i = rows - 1; i >= 0; i--)
                {
                    colValues.Enqueue(matrix[i][line]);
                }
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    colValues.Enqueue(matrix[i][line]);
                }
            }

            for (int i = 0; i < m; i++)
            {
                int t = colValues.Dequeue();
                colValues.Enqueue(t);
            }

            if (direction == "down")
            {
                for (int i = rows - 1; i >= 0; i--)
                {
                    matrix[i][line] = colValues.Dequeue();
                }
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    matrix[i][line] = colValues.Dequeue();
                }
            }
        }

        private static void MoveLeftOrRight(int line, long moves, string direction)
        {
            int m = (int)(moves % cols);

            var colValues = new Queue<int>();

            if (direction == "right")
            {
                for (int i = cols - 1; i >= 0; i--)
                {
                    colValues.Enqueue(matrix[line][i]);
                }
            }
            else
            {
                for (int i = 0; i < cols; i++)
                {
                    colValues.Enqueue(matrix[line][i]);
                }
            }

            for (int i = 0; i < m; i++)
            {
                int t = colValues.Dequeue();
                colValues.Enqueue(t);
            }

            if (direction == "right")
            {
                for (int i = cols - 1; i >= 0; i--)
                {
                    matrix[line][i] = colValues.Dequeue();
                }
            }
            else
            {
                for (int i = 0; i < cols; i++)
                {
                    matrix[line][i] = colValues.Dequeue();
                }
            }
        }

        private static void RearrangeMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int initValue = i * cols + j + 1;
                    int currentValue = matrix[i][j];

                    if (initValue != currentValue)
                    {
                        for (int k = 0; k < rows; k++)
                        {
                            var currentRow = matrix[k];

                            int index = Array.IndexOf(currentRow, initValue);

                            if (index > -1)
                            {
                                matrix[k][index] = currentValue;
                                matrix[i][j] = initValue;
                                Console.WriteLine($"Swap ({i}, {j}) with ({k}, {index})");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                }
            }
        }
    }
}