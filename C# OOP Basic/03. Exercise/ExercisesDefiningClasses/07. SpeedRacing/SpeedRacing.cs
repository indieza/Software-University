using System;
using System.Collections.Generic;

internal class SpeedRacing
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        for (int i = 0; i < n; i++)
        {
            string[] items = Console.ReadLine().Split();
            string carModel = items[0];
            decimal fuelAmount = decimal.Parse(items[1]);
            decimal fuelConsumationFor1km = decimal.Parse(items[2]);
            cars.Add(carModel, new Car(carModel, fuelAmount, fuelConsumationFor1km));
        }

        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] items = command.Split();
            string carModel = items[1];
            decimal amountOfKm = decimal.Parse(items[2]);
            bool canTakeIt = cars[carModel].CanTakeTheDistance(amountOfKm);

            if (!canTakeIt)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

            command = Console.ReadLine();
        }

        Console.WriteLine(string.Join("\n", cars.Values));
    }
}