namespace _08.MapDistricts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MapDistricts
    {
        private static void Main()
        {
            var cities = new Dictionary<string, List<long>>();
            var cityPopulations = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var minPopulation = long.Parse(Console.ReadLine());

            foreach (var pair in cityPopulations)
            {
                var tokens = pair.Split(':');
                var city = tokens[0];
                var district = long.Parse(tokens[1]);

                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new List<long>());
                }

                cities[city].Add(district);
            }

            var filtered = cities
                .Where(pair => pair.Value.Sum() >= minPopulation)
                .OrderByDescending(pair => pair.Value.Sum());

            foreach (var pair in filtered)
            {
                var districts =
                    pair.Value
                        .OrderByDescending(x => x)
                        .Take(5);
                Console.WriteLine($"{pair.Key}: {string.Join(" ", districts)}");
            }
        }
    }
}