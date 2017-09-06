using System;

internal class DangerousFloor
{
    private const int N = 8;

    private static void Main()
    {
        string[,] matrix = FillMatrix();

        string line = Console.ReadLine();

        while (line != "END")
        {
            string piece = line[0].ToString();
            string[] cordinates = line
                .Substring(1, line.Length - 1)
                .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            char[] currentPossitionItems = cordinates[0].ToCharArray();
            char[] finalPossitionItems = cordinates[1].ToCharArray();

            int currentPossitionRow = int.Parse(currentPossitionItems[0].ToString());
            int currentPossitionCol = int.Parse(currentPossitionItems[1].ToString());

            int finalPossitionRow = int.Parse(finalPossitionItems[0].ToString());
            int finalPossitionCol = int.Parse(finalPossitionItems[1].ToString());

            if (matrix[currentPossitionRow, currentPossitionCol] != piece)
            {
                Console.WriteLine("There is no such a piece!");
            }
            else
            {
                switch (piece)
                {
                    case "K":
                        if (CheckIsOutsideOfTheBoard(finalPossitionRow, finalPossitionCol))
                        {
                            Console.WriteLine("Move go out of board!");
                        }
                        else
                        {
                            if (!((currentPossitionRow + 1 == finalPossitionRow &&
                                   currentPossitionCol == finalPossitionCol)
                                  || (currentPossitionRow + 1 == finalPossitionRow &&
                                      currentPossitionCol + 1 == finalPossitionCol)
                                  || (currentPossitionRow == finalPossitionRow &&
                                      currentPossitionCol + 1 == finalPossitionCol)
                                  || (currentPossitionRow - 1 == finalPossitionRow &&
                                      currentPossitionCol + 1 == finalPossitionCol)
                                  || (currentPossitionRow - 1 == finalPossitionRow &&
                                      currentPossitionCol == finalPossitionCol)
                                  || (currentPossitionRow - 1 == finalPossitionRow &&
                                      currentPossitionCol - 1 == finalPossitionCol)
                                  || (currentPossitionRow == finalPossitionRow &&
                                      currentPossitionCol - 1 == finalPossitionCol)
                                  || (currentPossitionRow + 1 == finalPossitionRow &&
                                      currentPossitionCol - 1 == finalPossitionCol)))
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            else
                            {
                                matrix[currentPossitionRow, currentPossitionCol] = "x";
                                matrix[finalPossitionRow, finalPossitionCol] = "K";
                            }
                        }
                        break;

                    case "R":
                        if (CheckIsOutsideOfTheBoard(finalPossitionRow, finalPossitionCol))
                        {
                            Console.WriteLine("Move go out of board!");
                        }
                        else
                        {
                            if (!((currentPossitionRow < finalPossitionRow && currentPossitionCol == finalPossitionCol)
                                  || (currentPossitionRow > finalPossitionRow && currentPossitionCol == finalPossitionCol)
                                  || (currentPossitionCol > finalPossitionCol && currentPossitionRow == finalPossitionRow)
                                  || (currentPossitionCol < finalPossitionCol && currentPossitionRow == finalPossitionRow)))
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            else
                            {
                                matrix[currentPossitionRow, currentPossitionCol] = "x";
                                matrix[finalPossitionRow, finalPossitionCol] = "R";
                            }
                        }
                        break;

                    case "B":
                        if (CheckIsOutsideOfTheBoard(finalPossitionRow, finalPossitionCol))
                        {
                            Console.WriteLine("Move go out of board!");
                        }
                        else
                        {
                            if (Math.Abs(currentPossitionRow - finalPossitionRow) != Math.Abs(currentPossitionCol - finalPossitionCol))
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            else
                            {
                                matrix[currentPossitionRow, currentPossitionCol] = "x";
                                matrix[finalPossitionRow, finalPossitionCol] = "B";
                            }
                        }
                        break;

                    case "Q":
                        if (CheckIsOutsideOfTheBoard(finalPossitionRow, finalPossitionCol))
                        {
                            Console.WriteLine("Move go out of board!");
                        }
                        else
                        {
                            if (!((currentPossitionRow < finalPossitionRow && currentPossitionCol == finalPossitionCol)
                                  || (currentPossitionRow > finalPossitionRow && currentPossitionCol == finalPossitionCol)
                                  || (currentPossitionCol > finalPossitionCol && currentPossitionRow == finalPossitionRow)
                                  || (currentPossitionCol < finalPossitionCol && currentPossitionRow == finalPossitionRow)
                                  || (Math.Abs(currentPossitionRow - finalPossitionRow) == Math.Abs(currentPossitionCol - finalPossitionCol))))
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            else
                            {
                                matrix[currentPossitionRow, currentPossitionCol] = "x";
                                matrix[finalPossitionRow, finalPossitionCol] = "Q";
                            }
                        }
                        break;

                    case "P":
                        if (CheckIsOutsideOfTheBoard(finalPossitionRow, finalPossitionCol))
                        {
                            Console.WriteLine("Move go out of board!");
                        }
                        else
                        {
                            if (!(currentPossitionCol == finalPossitionCol && currentPossitionRow - 1 == finalPossitionRow))
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            else
                            {
                                matrix[currentPossitionRow, currentPossitionCol] = "x";
                                matrix[finalPossitionRow, finalPossitionCol] = "P";
                            }
                        }
                        break;
                }
            }

            line = Console.ReadLine();
        }
    }

    private static bool CheckIsOutsideOfTheBoard(int finalPossitionRow, int finalPossitionCol)
    {
        return finalPossitionRow >= N
               || finalPossitionRow < 0
               || finalPossitionCol >= N
               || finalPossitionCol < 0;
    }

    private static string[,] FillMatrix()
    {
        string[,] matrix = new string[N, N];

        for (int row = 0; row < N; row++)
        {
            string[] line = Console.ReadLine().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < N; col++)
            {
                matrix[row, col] = line[col];
            }
        }

        return matrix;
    }
}