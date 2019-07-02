using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class StartUp
    {
        private static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimestions[0];
            int cols = dimestions[1];

            int[,] field = FillField(rows, cols);

            string command = Console.ReadLine();
            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] enemyCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int enemyRow = enemyCoordinates[0];
                int enemyCol = enemyCoordinates[1];

                while (enemyRow >= 0 && enemyCol >= 0)
                {
                    if (enemyRow >= 0 && enemyRow < field.GetLength(0) &&
                        enemyCol >= 0 && enemyCol < field.GetLength(1))
                    {
                        field[enemyRow, enemyCol] = 0;
                    }

                    enemyRow--;
                    enemyCol--;
                }

                int playerRow = playerCoordinates[0];
                int playerCol = playerCoordinates[1];

                while (playerRow >= 0 && playerCol < field.GetLength(1))
                {
                    if (playerRow >= 0 && playerRow < field.GetLength(0) &&
                        playerCol >= 0 && playerCol < field.GetLength(1))
                    {
                        sum += field[playerRow, playerCol];
                    }

                    playerCol++;
                    playerRow--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static int[,] FillField(int rows, int cols)
        {
            int[,] field = new int[rows, cols];

            int value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = value++;
                }
            }

            return field;
        }
    }
}