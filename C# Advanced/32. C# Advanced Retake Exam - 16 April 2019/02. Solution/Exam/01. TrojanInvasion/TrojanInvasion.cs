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
            List<int> platesSpartanDefense = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> warriors = new List<int>();

            for (int wave = 1; wave <= waves; wave++)
            {
                if (platesSpartanDefense.Count == 0)
                {
                    break;
                }
                warriors = Console.ReadLine().Split().Select(int.Parse).ToList();

                if (wave % 3 == 0)
                {
                    platesSpartanDefense.Add(int.Parse(Console.ReadLine()));
                }

                while (warriors.Count != 0 && platesSpartanDefense.Count != 0)
                {
                    int currentWarrier = warriors.Last();
                    int currentPlate = platesSpartanDefense[0];

                    if (currentWarrier == currentPlate)
                    {
                        warriors.RemoveAt(warriors.Count - 1);
                        platesSpartanDefense.RemoveAt(0);
                    }
                    else if (currentPlate > currentWarrier)
                    {
                        currentPlate -= currentWarrier;
                        warriors.RemoveAt(warriors.Count - 1);
                        platesSpartanDefense[0] = currentPlate;
                    }
                    else if (currentWarrier > currentPlate)
                    {
                        currentWarrier -= currentPlate;
                        platesSpartanDefense.RemoveAt(0);
                        warriors.RemoveAt(warriors.Count - 1);
                        warriors.Add(currentWarrier);
                    }
                }
            }

            if (platesSpartanDefense.Count > 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesSpartanDefense)}");
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warriors.ToArray().Reverse())}");
            }
        }
    }
}