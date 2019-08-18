using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SeashellTreasure
{
    public class SeashellTreasure
    {
        private static char[][] field;
        private static int rows;
        private static string line;
        private static string[] commandItems;
        private static int targetRow;
        private static int targetCol;
        private static string direction;
        private static List<char> collected;
        private static List<char> stolen;

        private static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            field = new char[rows][];
            FillField();
            collected = new List<char>();
            stolen = new List<char>();

            line = Console.ReadLine();

            while (line != "Sunset")
            {
                commandItems = line.Split();

                ExecuteCommand();

                line = Console.ReadLine();
            }

            PrintField();
            PrintInfo();
        }

        private static void PrintInfo()
        {
            if (collected.Count != 0)
            {
                Console.WriteLine(
                    $"Collected seashells: {collected.Count} -> {string.Join(", ", collected)}");
            }
            else
            {
                Console.WriteLine("Collected seashells: 0");
            }

            Console.WriteLine($"Stolen seashells: {stolen.Count}");
        }

        private static void PrintField()
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", field[row]));
            }
        }

        private static void ExecuteCommand()
        {
            switch (commandItems[0])
            {
                case "Collect":
                    CollectCommand();
                    break;

                case "Steal":
                    targetRow = int.Parse(commandItems[1]);
                    targetCol = int.Parse(commandItems[2]);
                    direction = commandItems[3];
                    break;

                default:
                    break;
            }
        }

        private static void CollectCommand()
        {
            targetRow = int.Parse(commandItems[1]);
            targetCol = int.Parse(commandItems[2]);

            if (targetRow >= 0 && targetRow <= rows - 1)
            {
                if (targetCol >= 0 && targetCol <= field[targetRow].Length - 1)
                {
                    if (field[targetRow][targetCol] != '-')
                    {
                        collected.Add(field[targetRow][targetCol]);
                        field[targetRow][targetCol] = '-';
                    }
                }
            }
        }

        private static void FillField()
        {
            for (int row = 0; row < rows; row++)
            {
                List<char> currentRow = Console.ReadLine()
                 .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(char.Parse)
                 .ToList();

                field[row] = currentRow.ToArray();
            }
        }
    }
}