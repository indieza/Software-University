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
        private static string direction;
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

        private static void ExecuteCommand()
        {
            switch (commandItems[0])
            {
                case "Harvest":
                    targetRow = int.Parse(commandItems[1]);
                    targetCol = int.Parse(commandItems[2]);
                    HarvestCommand();
                    break;

                case "Mole":
                    targetRow = int.Parse(commandItems[1]);
                    targetCol = int.Parse(commandItems[2]);
                    direction = commandItems[3];
                    MoleCommand();
                    break;

                default:
                    break;
            }
        }

        private static void MoleCommand()
        {
            switch (direction)
            {
                case "up":
                    if (targetRow >= 0 && targetRow <= rows - 1)
                    {
                        int counter = 0;

                        if (targetCol <= field[targetRow].Length - 1 && targetCol >= 0)
                        {
                            for (int row = targetRow; row >= 0; row--)
                            {
                                if (counter++ % 2 == 0)
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
                        int counter = 0;

                        if (targetCol <= field[targetRow].Length - 1 && targetCol >= 0)
                        {
                            for (int row = targetRow; row < rows; row++)
                            {
                                if (counter++ % 2 == 0)
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
                        int counter = 0;

                        if (targetCol <= field[targetRow].Length - 1 && targetCol >= 0)
                        {
                            for (int col = targetCol; col >= 0; col--)
                            {
                                if (counter++ % 2 == 0)
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
                        int counter = 0;

                        if (targetCol <= field[targetRow].Length - 1 && targetCol >= 0)
                        {
                            for (int col = targetCol; col < field[targetRow].Length; col++)
                            {
                                if (counter++ % 2 == 0)
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

        private static void HarvestCommand()
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

        private static void PrintField()
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", field[row]));
            }
        }

        private static void FillField()
        {
            for (int row = 0; row < rows; row++)
            {
                field[row] = Console.ReadLine().Split().Select(char.Parse).ToArray();
            }
        }
    }
}