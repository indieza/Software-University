using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TrojanInvasion
{
    public class TrojanInvasion
    {
        private static void Main()
        {
            int waves = int.Parse(Console.ReadLine());

            List<int> plates = new List<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> warriors = new Stack<int>();

            for (int wave = 1; wave <= waves; wave++)
            {
                warriors = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

                if (wave % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }

                while (warriors.Count != 0 && plates.Count != 0)
                {
                    int currentPlate = plates[0];
                    int currentWarrior = warriors.Pop();

                    if (currentWarrior > currentPlate)
                    {
                        currentWarrior -= currentPlate;
                        warriors.Push(currentWarrior);
                        plates.RemoveAt(0);
                    }
                    else if (currentPlate > currentWarrior)
                    {
                        currentPlate -= currentWarrior;
                        plates[0] = currentPlate;
                    }
                    else
                    {
                        plates.RemoveAt(0);
                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }
            }

            if (plates.Count == 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");

                if (warriors.Count != 0)
                {
                    Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
                }
            }
            if (warriors.Count == 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");

                if (plates.Count != 0)
                {
                    Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
                }
            }
        }
    }
}