using System;
using System.Linq;

namespace _02.ParkingFeud
{
    public class ParkingFeud
    {
        private static void Main()
        {
            bool[][] parking = CreateParking();

            int entranceNumber = int.Parse(Console.ReadLine());

            TryPark(entranceNumber, parking);
        }

        private static void TryPark(int entranceNumber, bool[][] parking)
        {
            bool parked = false;
            int totalDistance = 0;
            int maxColumnIndex = parking[0].Length - 1;
            string parkingSpot = null;

            while (!parked)
            {
                string positionsInput = Console.ReadLine();
                string[] positions = positionsInput.Split();

                int index = entranceNumber - 1;
                parkingSpot = positions[index];

                int conflictIndex = -1;

                for (int i = 0; i < positions.Length; i++)
                {
                    if (parkingSpot == positions[i] && i != index)
                    {
                        conflictIndex = i;
                    }
                }

                int currentDistance = CalculateDistance(entranceNumber, parkingSpot, maxColumnIndex);
                totalDistance += currentDistance;

                if (conflictIndex >= 0)
                {
                    int otherCarDistance = CalculateDistance(conflictIndex + 1, positions[conflictIndex], maxColumnIndex);
                    if (currentDistance > otherCarDistance)
                    {
                        totalDistance += currentDistance;
                    }
                    else
                    {
                        parked = true;
                    }
                }
                else
                {
                    parked = true;
                }
            }

            ParkSuccess(parkingSpot, totalDistance);
        }

        private static void ParkSuccess(string parkingSpot, int totalDistance)
        {
            Console.WriteLine($"Parked successfully at {parkingSpot}.");
            Console.WriteLine($"Total Distance Passed: {totalDistance}");
        }

        private static int CalculateDistance(int entranceNumber, string targetParkingSpot, int finalColumnIndex)
        {
            bool goingLeft = true;
            int[] currentPosition = new int[] { entranceNumber * 2 - 1, 0 };
            int[] parkingSpotPosition = GetParkingSpotPosition(targetParkingSpot);
            int distance = 0;

            while (!AtSpot(currentPosition, parkingSpotPosition))
            {
                distance++;

                currentPosition[1] += goingLeft ? 1 : -1;

                bool reachedTheEnd = currentPosition[1] == finalColumnIndex && goingLeft ||
                    currentPosition[1] == 0 && !goingLeft;

                if (reachedTheEnd)
                {
                    bool targetRowIsAbove = currentPosition[0] > parkingSpotPosition[0];
                    currentPosition[0] += targetRowIsAbove ? -2 : 2;
                    goingLeft = !goingLeft;
                    distance += 2;
                }
            }

            return distance;
        }

        private static bool AtSpot(int[] currentPosition, int[] parkingSpotPosition)
        {
            bool sameCol = currentPosition[1] == parkingSpotPosition[1];

            bool rowAboveSpot = currentPosition[0] == parkingSpotPosition[0] - 1;
            bool rowBelowSpot = currentPosition[0] == parkingSpotPosition[0] + 1;
            bool rowNextToSpot = rowAboveSpot || rowBelowSpot;

            return sameCol && rowNextToSpot;
        }

        private static int[] GetParkingSpotPosition(string parkingSpot)
        {
            char letter = parkingSpot[0];
            int row = (int.Parse(parkingSpot.Substring(1)) - 1) * 2;
            int column = letter - 'A' + 1;

            return new int[] { row, column };
        }

        private static bool[][] CreateParking()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int actualRows = dimensions[0] * 2 - 1;
            int actualCols = dimensions[1] + 2;

            bool[][] parking = new bool[actualRows][];

            for (int rowNumber = 0; rowNumber < actualRows; rowNumber++)
            {
                parking[rowNumber] = new bool[actualCols];
            }

            return parking;
        }
    }
}