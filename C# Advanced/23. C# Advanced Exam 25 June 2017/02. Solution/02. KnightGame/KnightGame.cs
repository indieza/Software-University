using System;

internal class KnightGame
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = new char[n, n];

        FillMatrix(n, matrix);

        int hittedHourse = 0;
        int bestRow = 0;
        int bestCol = 0;
        int counter = 0;

        while (true)
        {
            int savedHourse = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    hittedHourse = CheckMatrix(matrix, row, col, n, hittedHourse);

                    if (hittedHourse > savedHourse)
                    {
                        savedHourse = hittedHourse;
                        bestRow = row;
                        bestCol = col;
                    }

                    hittedHourse = 0;
                }
            }
            if (savedHourse == 0)
            {
                break;
            }

            matrix[bestRow, bestCol] = '0';
            counter++;
            bestRow = 0;
            bestCol = 0;
        }

        Console.WriteLine(counter);
    }

    private static int CheckMatrix(char[,] matrix, int row, int col, int n, int hittedHourse)
    {
        if (matrix[row, col] == 'K')
        {
            if (row - 2 >= 0 && col + 1 < n && matrix[row - 2, col + 1] == 'K')
            {
                hittedHourse++;
            }
            if (row - 1 >= 0 && col + 2 < n && matrix[row - 1, col + 2] == 'K')
            {
                hittedHourse++;
            }
            if (row + 1 < n && col + 2 < n && matrix[row + 1, col + 2] == 'K')
            {
                hittedHourse++;
            }
            if (row + 2 < n && col + 1 < n && matrix[row + 2, col + 1] == 'K')
            {
                hittedHourse++;
            }
            if (row + 2 < n && col - 1 >= 0 && matrix[row + 2, col - 1] == 'K')
            {
                hittedHourse++;
            }
            if (row + 1 < n && col - 2 >= 0 && matrix[row + 1, col - 2] == 'K')
            {
                hittedHourse++;
            }
            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2] == 'K')
            {
                hittedHourse++;
            }
            if (row - 2 >= 0 && col - 1 >= 0 && matrix[row - 2, col - 1] == 'K')
            {
                hittedHourse++;
            }
        }
        return hittedHourse;
    }

    private static void FillMatrix(int n, char[,] matrix)
    {
        for (int row = 0; row < n; row++)
        {
            char[] line = Console.ReadLine().ToCharArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = line[col];
            }
        }
    }
}