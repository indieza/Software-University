namespace RallyRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();
            var matrix = new string[n, n];

            var tunnels = new Dictionary<int, int>();
            var distance = 0;
            var finalRow = -1;
            var finalCol = -1;
            var isFinished = false;

            for (int row = 0; row < n; row++)
            {
                var inputLine = Console.ReadLine()
                 .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

                if (inputLine.Any(x => x.ToUpper() == "T"))
                {
                    for (int index = 0; index < n; index++)
                    {
                        if (inputLine[index].ToUpper() == "T")
                        {
                            tunnels.Add(row, index);
                        }
                    }
                }

                if (inputLine.Any(x => x.ToUpper() == "F"))
                {
                    finalRow = row;
                    finalCol = inputLine.IndexOf("F");
                }

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            var currentRow = 0;
            var currentCol = 0;

            var command = Console.ReadLine();

            while (command.ToUpper() != "END" && !isFinished)
            {
                switch (command.ToUpper())
                {
                    case "LEFT":
                        currentCol--;

                        if (currentCol == finalCol && currentRow == finalRow)
                        {
                            distance += 10;
                            isFinished = true;
                            break;
                        }

                        if (tunnels.Any(x => x.Key == currentRow && x.Value == currentCol))
                        {
                            tunnels.Remove(currentRow);
                            matrix[currentRow, currentCol] = ".";
                            matrix[tunnels.Last().Key, tunnels.Last().Value] = ".";
                            currentRow = tunnels.Last().Key;
                            currentCol = tunnels.Last().Value;
                            tunnels.Clear();

                            distance += 30;
                        }
                        else
                        {
                            matrix[currentRow, currentCol] = ".";
                            distance += 10;
                        }

                        break;

                    case "RIGHT":
                        currentCol++;

                        if (currentCol == finalCol && currentRow == finalRow)
                        {
                            distance += 10;
                            isFinished = true;
                            break;
                        }

                        if (tunnels.Any(x => x.Key == currentRow && x.Value == currentCol))
                        {
                            tunnels.Remove(currentRow);
                            matrix[currentRow, currentCol] = ".";
                            matrix[tunnels.Last().Key, tunnels.Last().Value] = ".";
                            currentRow = tunnels.Last().Key;
                            currentCol = tunnels.Last().Value;
                            tunnels.Clear();

                            distance += 30;
                        }
                        else
                        {
                            matrix[currentRow, currentCol] = ".";
                            distance += 10;
                        }
                        break;

                    case "UP":
                        currentRow--;

                        if (currentCol == finalCol && currentRow == finalRow)
                        {
                            distance += 10;
                            isFinished = true;
                            break;
                        }

                        if (tunnels.Any(x => x.Key == currentRow && x.Value == currentCol))
                        {
                            tunnels.Remove(currentRow);
                            matrix[currentRow, currentCol] = ".";
                            matrix[tunnels.Last().Key, tunnels.Last().Value] = ".";
                            currentRow = tunnels.Last().Key;
                            currentCol = tunnels.Last().Value;
                            tunnels.Clear();

                            distance += 30;
                        }
                        else
                        {
                            matrix[currentRow, currentCol] = ".";
                            distance += 10;
                        }
                        break;

                    case "DOWN":
                        currentRow++;

                        if (currentCol == finalCol && currentRow == finalRow)
                        {
                            distance += 10;
                            isFinished = true;
                            break;
                        }

                        if (tunnels.Any(x => x.Key == currentRow && x.Value == currentCol))
                        {
                            tunnels.Remove(currentRow);
                            matrix[currentRow, currentCol] = ".";
                            matrix[tunnels.Last().Key, tunnels.Last().Value] = ".";
                            currentRow = tunnels.Last().Key;
                            currentCol = tunnels.Last().Value;
                            tunnels.Clear();

                            distance += 30;
                        }
                        else
                        {
                            matrix[currentRow, currentCol] = ".";
                            distance += 10;
                        }
                        break;

                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            matrix[currentRow, currentCol] = "C";

            if (isFinished)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {distance} km.");

            for (int row = 0; row < n; row++)
            {
                List<string> printLine = new List<string>();

                for (int col = 0; col < n; col++)
                {
                    printLine.Add(matrix[row, col]);
                }

                Console.WriteLine(string.Join("", printLine));
            }
        }
    }
}