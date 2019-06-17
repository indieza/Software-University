using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheGarden
{
    public class TheGarden
    {
        private static int rows;
        private static char[][] field;
        private static string[] commandItems;
        private static int targetRow;
        private static int targetCol;
        private static string directory;
        private static Dictionary<char, int> information;

        private static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            field = new char[rows][];

            FillField();
            information = new Dictionary<char, int>()
            {
                { 'C', 0 },
                { 'P', 0 },
                { 'L', 0 },
                { 'H', 0 }
            };

            string line = Console.ReadLine();

            while (line != "End of Harvest")
            {
                commandItems = line.Split();
                ExecuteCommand();

                line = Console.ReadLine();
            }

            PrintField();
            PrintInformation();
        }

        private static void ExecuteCommand()
        {
            string command = commandItems[0];

            switch (command)
            {
                case "Harvest":
                    targetRow = int.Parse(commandItems[1]);
                    targetCol = int.Parse(commandItems[2]);

                    HarvestCell();
                    break;

                case "Mole":
                    targetRow = int.Parse(commandItems[1]);
                    targetCol = int.Parse(commandItems[2]);
                    directory = commandItems[3];

                    MoleCell();
                    break;

                default:
                    break;
            }
        }

        private static void MoleCell()
        {
            switch (directory)
            {
                case "up":
                    if (targetRow >= 0 && targetRow <= rows - 1)
                    {
                        int count = 0;

                        for (int row = targetRow; row >= 0; row--)
                        {
                            if (targetCol >= 0 && targetCol <= field[targetRow].Length - 1)
                            {
                                if (count++ % 2 == 0)
                                {
                                    if (field[row][targetCol] != ' ')
                                    {
                                        field[row][targetCol] = ' ';
                                        information['H']++;
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "down":
                    if (targetRow >= 0 && targetRow <= rows - 1)
                    {
                        int count = 0;

                        for (int row = targetRow; row < rows; row++)
                        {
                            if (targetCol >= 0 && targetCol <= field[targetRow].Length - 1)
                            {
                                if (count++ % 2 == 0)
                                {
                                    if (field[row][targetCol] != ' ')
                                    {
                                        field[row][targetCol] = ' ';
                                        information['H']++;
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "left":
                    if (targetRow >= 0 && targetRow <= rows - 1)
                    {
                        if (targetCol >= 0 && targetCol <= field[targetRow].Length - 1)
                        {
                            int count = 0;

                            for (int col = targetCol; col >= 0; col--)
                            {
                                if (count++ % 2 == 0)
                                {
                                    if (field[targetRow][col] != ' ')
                                    {
                                        field[targetRow][col] = ' ';
                                        information['H']++;
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "right":
                    if (targetRow >= 0 && targetRow <= rows - 1)
                    {
                        if (targetCol <= field[targetRow].Length - 1 && targetCol >= 0)
                        {
                            int count = 0;

                            for (int col = targetCol; col < field[targetRow].Length; col++)
                            {
                                if (count++ % 2 == 0)
                                {
                                    if (field[targetRow][col] != ' ')
                                    {
                                        field[targetRow][col] = ' ';
                                        information['H']++;
                                    }
                                }
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private static void HarvestCell()
        {
            if (targetRow >= 0 && targetRow <= rows - 1)
            {
                if (targetCol <= field[targetRow].Length - 1 && targetCol >= 0)
                {
                    if (field[targetRow][targetCol] != ' ')
                    {
                        information[field[targetRow][targetCol]]++;
                        field[targetRow][targetCol] = ' ';
                    }
                }
            }
        }

        private static void FillField()
        {
            for (int row = 0; row < rows; row++)
            {
                field[row] = Console.ReadLine().Split().Select(char.Parse).ToArray();
            }
        }

        private static void PrintField()
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", field[row]));
            }
        }

        private static void PrintInformation()
        {
            foreach (var item in information)
            {
                switch (item.Key)
                {
                    case 'C':
                        Console.WriteLine($"Carrots: {item.Value}");
                        break;

                    case 'P':
                        Console.WriteLine($"Potatoes: {item.Value}");
                        break;

                    case 'L':
                        Console.WriteLine($"Lettuce: {item.Value}");
                        break;

                    case 'H':
                        Console.WriteLine($"Harmed vegetables: {item.Value}");
                        break;

                    default:
                        break;
                }
            }
        }
    }
}