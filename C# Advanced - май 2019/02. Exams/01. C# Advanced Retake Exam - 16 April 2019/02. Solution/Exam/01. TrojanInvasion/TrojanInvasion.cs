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

            List<int> plates = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Stack<int> warriors = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                warriors = new Stack<int>(Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

                if (i % 3 == 0)
                {
                    int bonusPlate = int.Parse(Console.ReadLine());
                    plates.Add(bonusPlate);
                }

                while (warriors.Count != 0 && plates.Count != 0)
                {
                    int warrior = warriors.Pop();
                    int plate = plates[0];

                    if (warrior > plate)
                    {
                        warrior -= plate;
                        warriors.Push(warrior);
                        plates.RemoveAt(0);
                    }
                    else if (plate > warrior)
                    {
                        plates[0] = plate - warrior;
                    }
                    else if (warrior == plate)
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
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
            }
            if (warriors.Count != 0)
            {
                Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
            }
            if (plates.Count != 0)
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}