using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HelensAbduction
{
    public class HelensAbduction
    {
        private static int parisEnergy;
        private static int rows;
        private static char[,] field;
        private static string[] commandItems;
        private static string command;
        private static int targetRow;
        private static int targetCol;

        private static void Main()
        {
            parisEnergy = int.Parse(Console.ReadLine());
            rows = int.Parse(Console.ReadLine());

            field = new char[rows, rows];

            FillFiled();

            while (true)
            {
                ExecuteCommandParameters();

                switch (command.ToLower())
                {
                    case "up":
                        break;

                    case "down":
                        break;

                    case "left":
                        break;

                    case "right":
                        break;

                    default:
                        break;
                }
            }
        }

        private static void ExecuteCommandParameters()
        {
            commandItems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            command = commandItems[0];
            targetRow = int.Parse(commandItems[1]);
            targetCol = int.Parse(commandItems[2]);
        }

        private static void FillFiled()
        {
            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rows; col++)
                {
                    field[row, col] = currentRow[col];
                }
            }
        }
    }
}