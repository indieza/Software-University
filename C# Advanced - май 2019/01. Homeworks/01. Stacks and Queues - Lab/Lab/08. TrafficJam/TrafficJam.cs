using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    public class TrafficJam
    {
        private static void Main()
        {
            Queue<string> cars = new Queue<string>();

            int n = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            int passedCars = 0;

            while (line != "end")
            {
                if (line == "green")
                {
                    int carsCount = Math.Min(n, cars.Count);

                    for (int i = 0; i < carsCount; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        passedCars++;
                    }
                }
                else
                {
                    cars.Enqueue(line);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}