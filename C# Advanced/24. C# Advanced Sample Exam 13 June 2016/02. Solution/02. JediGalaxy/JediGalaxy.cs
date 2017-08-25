using System;
using System.Linq;

internal class JediGalaxy
{
    private static void Main()
    {
        int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = dimensions[0];
        int cols = dimensions[1];

        int[,] matrix = new int[rows, cols];

        int couonter = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = couonter;
                couonter++;
            }
        }

        string line = Console.ReadLine();

        long result = 0;

        while (line != "Let the Force be with you")
        {
            int[] cordinatesJedi = line.Split().Select(int.Parse).ToArray();
            int[] cordinatesEvil = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int jediRow = cordinatesJedi[0];
            int jediCol = cordinatesJedi[1];

            int evellRow = cordinatesEvil[0];
            int evilCol = cordinatesEvil[1];

            while (evellRow >= 0 && evilCol >= 0)
            {
                if (Checkmatrix(evellRow, evilCol, matrix))
                {
                    matrix[evellRow, evilCol] = 0;
                }

                evellRow--;
                evilCol--;
            }

            while (jediRow >= 0 && jediCol < cols)
            {
                if (Checkmatrix(jediRow, jediCol, matrix))
                {
                    result += matrix[jediRow, jediCol];
                }

                jediRow--;
                jediCol++;
            }
            line = Console.ReadLine();
        }

        Console.WriteLine(result);
    }

    private static bool Checkmatrix(int rows, int cols, int[,] matrix)
    {
        bool check = rows >= 0 && cols >= 0 && rows < matrix.GetLength(0) && cols < matrix.GetLength(1);
        return check;
    }
}