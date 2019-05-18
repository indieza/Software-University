using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    public class ParkingLot
    {
        private static void Main()
        {
            HashSet<string> cars = new HashSet<string>();

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] items = line.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = items[0];
                string car = items[1];

                if (command == "IN")
                {
                    cars.Add(car);
                }
                if (command == "OUT")
                {
                    cars.Remove(car);
                }

                line = Console.ReadLine();
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join("\n", cars));
            }
        }
    }
}