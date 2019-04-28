using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SportCards
{
    public class SportCards
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, decimal>> cards =
                new Dictionary<string, Dictionary<string, decimal>>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] items = line.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                if (items[0] == "check")
                {
                    if (cards.ContainsKey(items[1]))
                    {
                        Console.WriteLine($"{items[1]} is available!");
                    }
                    else
                    {
                        Console.WriteLine($"{items[1]} is not available!");
                    }
                }
                else
                {
                    if (!cards.ContainsKey(items[0]))
                    {
                        cards.Add(items[0], new Dictionary<string, decimal>());
                    }
                    else if (!cards[items[0]].ContainsKey(items[1]))
                    {
                        cards[items[0]].Add(items[1], decimal.Parse(items[2]));
                    }

                    cards[items[0]][items[1]] = decimal.Parse(items[2]);
                }

                line = Console.ReadLine();
            }

            foreach (var card in cards.OrderByDescending(c => c.Value.Count))
            {
                Console.WriteLine($"{card.Key}:");

                foreach (var sport in card.Value.OrderBy(s => s.Key))
                {
                    Console.WriteLine($"  -{sport.Key} - {Math.Round(sport.Value, 2)}");
                }
            }
        }
    }
}