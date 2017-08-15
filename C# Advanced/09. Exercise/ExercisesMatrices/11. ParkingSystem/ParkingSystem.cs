namespace _11.ParkingSystem
{
    using System;
    using System.Collections.Generic;

    internal class ParkingSystem
    {
        private static void Main()
        {
            string[] size = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int cols = int.Parse(size[1]);

            Dictionary<int, HashSet<int>> parking = new Dictionary<int, HashSet<int>>();

            string input = Console.ReadLine();

            while (input != "stop")
            {
                string[] parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int entryRow = int.Parse(parameters[0]);
                int desiredRow = int.Parse(parameters[1]);
                int desiredCol = int.Parse(parameters[2]);

                int parkColumn = 0;

                if (!IsOccupied(parking, desiredRow, desiredCol))
                {
                    parkColumn = desiredCol;
                }
                else
                {
                    for (int i = 1; i < cols - 1; i++)
                    {
                        if (desiredCol - i > 0 &&
                            !IsOccupied(parking, desiredRow, desiredCol - i))
                        {
                            parkColumn = desiredCol - i;
                            break;
                        }

                        if (desiredCol + i < cols && !IsOccupied(parking, desiredRow, desiredCol + i))
                        {
                            parkColumn = desiredCol + i;
                            break;
                        }
                    }
                }

                if (parkColumn == 0)
                {
                    Console.WriteLine($"Row {desiredRow} full");
                }
                else
                {
                    parking[desiredRow].Add(parkColumn);
                    int steps = Math.Abs(entryRow - desiredRow) + 1 + parkColumn;
                    Console.WriteLine(steps);
                }

                input = Console.ReadLine();
            }
        }

        private static bool IsOccupied(Dictionary<int, HashSet<int>> parking, int row, int col)
        {
            if (parking.ContainsKey(row))
            {
                if (parking[row].Contains(col))
                {
                    return true;
                }
            }
            else
            {
                parking.Add(row, new HashSet<int>());
            }

            return false;
        }
    }
}