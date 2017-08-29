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
        int count = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = count;
                count++;
            }
        }

        string line = Console.ReadLine();

        long ivoStars = 0;

        while (line != "Let the Force be with you")
        {
            int[] ivoItems = line.Split().Select(int.Parse).ToArray();
            int[] devilItems = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int devilRows = devilItems[0];
            int devilCols = devilItems[1];

            while (devilRows >= 0 && devilCols >= 0)
            {
                if (devilRows < rows && devilCols < cols)
                {
                    matrix[devilRows, devilCols] = 0;
                }

                devilRows--;
                devilCols--;
            }

            int ivoRows = ivoItems[0];
            int ivoCols = ivoItems[1];

            while (ivoRows >= 0 && ivoCols < cols)
            {
                if (ivoRows >= 0 && ivoRows < rows && ivoCols >= 0 && ivoCols < cols)
                {
                    ivoStars += matrix[ivoRows, ivoCols];
                }

                ivoRows--;
                ivoCols++;
            }

            line = Console.ReadLine();
        }

        Console.WriteLine(ivoStars);
    }
}