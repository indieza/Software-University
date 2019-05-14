using System;
using System.Collections.Generic;

namespace _06.AutoRepairAndService
{
    public class AutoRepairAndService
    {
        private static void Main()
        {
            Queue<string> cars =
                new Queue<string>(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            Stack<string> servicedCars = new Stack<string>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] items = line.Split(new[] { "-", " " }, StringSplitOptions.RemoveEmptyEntries);

                if (items[0] == "Service" && cars.Count != 0)
                {
                    string car = cars.Dequeue();
                    Console.WriteLine($"Vehicle {car} got served.");
                    servicedCars.Push(car);
                }
                else if (items[0] == "CarInfo")
                {
                    if (cars.Contains(items[1]))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (items[0] == "History")
                {
                    Console.WriteLine(string.Join(", ", servicedCars));
                }

                line = Console.ReadLine();
            }

            if (cars.Count != 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", cars)}");
            }
            if (servicedCars.Count != 0)
            {
                Console.WriteLine($"Served vehicles: {string.Join(", ", servicedCars)}");
            }
        }
    }
}