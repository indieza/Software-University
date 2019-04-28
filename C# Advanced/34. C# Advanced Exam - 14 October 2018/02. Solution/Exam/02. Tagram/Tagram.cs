using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Tagram
{
    public class Tagram
    {
        private static void Main()
        {
            string line = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> people = new Dictionary<string, Dictionary<string, int>>();

            while (line != "end")
            {
                string[] items = line.Split(new[] { ' ', '>', '-' }, StringSplitOptions.RemoveEmptyEntries);

                if (items[0] == "ban")
                {
                    people.Remove(items[1]);
                }
                else
                {
                    if (!people.ContainsKey(items[0]))
                    {
                        people.Add(items[0], new Dictionary<string, int>());
                    }
                    if (!people[items[0]].ContainsKey(items[1]))
                    {
                        people[items[0]].Add(items[1], int.Parse(items[2]));
                    }
                    else
                    {
                        people[items[0]][items[1]] += int.Parse(items[2]);
                    }
                }

                line = Console.ReadLine();
            }

            foreach (var person in people
                .OrderByDescending(p => p.Value.Values.Sum())
                .ThenBy(p => p.Value.Keys.Count()))
            {
                Console.WriteLine($"{person.Key}");

                foreach (var info in person.Value)
                {
                    Console.WriteLine($"- {info.Key}: {info.Value}");
                }
            }
        }
    }
}