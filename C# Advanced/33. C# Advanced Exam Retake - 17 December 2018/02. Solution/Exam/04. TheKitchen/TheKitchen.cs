using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.TheKitchen
{
    public class TheKitchen
    {
        private static void Main()
        {
            List<int> knives = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> forks = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> sets = new List<int>();

            while (knives.Count != 0 && forks.Count != 0)
            {
                int knife = knives.Last();
                int fork = forks[0];

                if (knife > fork)
                {
                    sets.Add(knife + fork);
                    knives.RemoveAt(knives.Count - 1);
                    forks.RemoveAt(0);
                }
                else if (fork > knife)
                {
                    knives.RemoveAt(knives.Count - 1);
                }
                else if (fork == knife)
                {
                    forks.RemoveAt(0);
                    knife++;
                    knives.RemoveAt(knives.Count - 1);
                    knives.Add(knife);
                }
            }

            Console.WriteLine($"The biggest set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}