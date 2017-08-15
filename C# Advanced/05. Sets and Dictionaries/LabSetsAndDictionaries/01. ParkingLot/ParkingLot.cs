namespace _01.ParkingLot
{
    using System;
    using System.Collections.Generic;

    internal class ParkingLot
    {
        private static void Main()
        {
            var line = Console.ReadLine();

            var cars = new SortedSet<string>();

            while (line != "END")
            {
                var items = line.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                var command = items[0];
                var car = items[1];

                if (command == "IN")
                {
                    cars.Add(car);
                }
                else
                {
                    cars.Remove(car);
                }

                line = Console.ReadLine();
            }

            if (cars.Count != 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}