using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    public class Crossroads
    {
        private static void Main()
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();

            int passedCars = 0;
            bool isCrashed = false;

            while (command != "END")
            {
                if (command == "green")
                {
                    int savedGreenLight = greenLightDuration;
                    string currentCar = string.Empty;

                    while (cars.Count != 0 && savedGreenLight > 0)
                    {
                        currentCar = cars.Peek();
                        savedGreenLight -= currentCar.Length;
                        cars.Dequeue();
                        passedCars++;
                    }

                    int leftTime = freeWindow + savedGreenLight;

                    if (leftTime < 0)
                    {
                        int startIndex = Math.Abs(leftTime);
                        char symbol = currentCar[currentCar.Length - startIndex];
                        Console.WriteLine($"A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {symbol}.");
                        isCrashed = true;
                        break;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            if (!isCrashed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }
    }
}