using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Crossroads
{
    public class Crossroads
    {
        private static void Main()
        {
            int greenLightLength = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> lane = new Queue<string>();
            int totalCarsPassed = 0;

            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                if (line != "green")
                {
                    lane.Enqueue(line);
                    continue;
                }

                int currentGreenLight = greenLightLength;

                string passingCar = null;
                while (currentGreenLight > 0 && lane.Any())
                {
                    passingCar = lane.Dequeue();
                    currentGreenLight -= passingCar.Length;
                    totalCarsPassed++;
                }

                int freeWindowLeft = freeWindow + currentGreenLight;

                if (freeWindowLeft < 0)
                {
                    int symbolsThatDidntPass = Math.Abs(freeWindowLeft);
                    int indexOfHitSymbol = passingCar.Length - symbolsThatDidntPass;
                    char symbolHit = passingCar[indexOfHitSymbol];
                    Crash(passingCar, symbolHit);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }

        private static void Crash(string car, char symbolHit)
        {
            Console.WriteLine("A crash happened!");
            Console.WriteLine($"{car} was hit at {symbolHit}.");
            Environment.Exit(0);
        }
    }
}