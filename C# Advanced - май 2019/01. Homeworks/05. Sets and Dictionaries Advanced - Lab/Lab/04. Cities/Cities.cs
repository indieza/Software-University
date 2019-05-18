using System;
using System.Collections.Generic;

namespace _04.Cities
{
    public class Cities
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, List<string>>> countinents =
                new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] items = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string countinent = items[0];
                string country = items[1];
                string city = items[2];

                if (!countinents.ContainsKey(countinent))
                {
                    countinents.Add(countinent, new Dictionary<string, List<string>>());
                }
                if (!countinents[countinent].ContainsKey(country))
                {
                    countinents[countinent].Add(country, new List<string>());
                }

                countinents[countinent][country].Add(city);
            }

            foreach (var countinent in countinents)
            {
                Console.WriteLine($"{countinent.Key}:");

                foreach (var country in countinent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}