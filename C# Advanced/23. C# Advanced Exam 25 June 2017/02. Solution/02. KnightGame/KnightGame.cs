using System;

internal class KnightGame
{
    private static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var matrix = FillMatrix(n);

        var bestRow = 0;
        var bestCol = 0;
        var hittedHorses = 0;
        var counter = 0;

        while (true)
        {
            var savedHorse = 0;

            for (var row = 0; row < n; row++)
            {
                for (var col = 0; col < n; col++)
                {
                    hittedHorses = CheckHittedHorses(matrix, row, col, n, hittedHorses);

                    if (hittedHorses > savedHorse)
                    {
                        savedHorse = hittedHorses;
                        bestRow = row;
                        bestCol = col;
                    }

                    hittedHorses = 0;
                }
            }

            if (savedHorse <= 0)
            {
                break;
            }

            matrix[bestRow, bestCol] = '0';
            bestRow = 0;
            bestCol = 0;
            counter++;
        }

        Console.WriteLine(counter);
    }

    private static int CheckHittedHorses(char[,] matrix, int row, int col, int n, int hittedHorses)
    {
        if (matrix[row, col] == 'K')
        {
            if (row - 2 >= 0 && col + 1 < n && matrix[row - 2, col + 1] == 'K')
            {
                hittedHorses++;
            }
            if (row - 1 >= 0 && col + 2 < n && matrix[row - 1, col + 2] == 'K')
            {
                hittedHorses++;
            }
            if (row + 1 < n && col + 2 < n && matrix[row + 1, col + 2] == 'K')
            {
                hittedHorses++;
            }
            if (row + 2 < n && col + 1 < n && matrix[row + 2, col + 1] == 'K')
            {
                hittedHorses++;
            }
            if (row + 2 < n && col - 1 >= 0 && matrix[row + 2, col - 1] == 'K')
            {
                hittedHorses++;
            }
            if (row + 1 < n && col - 2 >= 0 && matrix[row + 1, col - 2] == 'K')
            {
                hittedHorses++;
            }
            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2] == 'K')
            {
                hittedHorses++;
            }
            if (row - 2 >= 0 && col - 1 >= 0 && matrix[row - 2, col - 1] == 'K')
            {
                hittedHorses++;
            }
        }
        return hittedHorses;
    }

    private static char[,] FillMatrix(int n)
    {
        var matrix = new char[n, n];

        for (var i = 0; i < n; i++)
        {
            var line = Console.ReadLine().ToCharArray();

            for (var j = 0; j < n; j++)
            {
                matrix[i, j] = line[j];
            }
        }
        return matrix;
    }
}