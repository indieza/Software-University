namespace _10_Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, long>> population =
                new Dictionary<string, Dictionary<string, long>>();
            string input;

            while ((input = Console.ReadLine()) != "report")
            {
                string[] data = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                string city = data[0];
                string country = data[1];
                int cityPopulation = int.Parse(data[2]);

                if (!population.ContainsKey(country))
                {
                    population[country] = new Dictionary<string, long>();
                }

                population[country][city] = cityPopulation;
            }

            foreach (var countryStats in population.OrderBy(x => -x.Value.Values.Sum()))
            {
                Console.WriteLine("{0} (total population: {1})", countryStats.Key, countryStats.Value.Values.Sum());

                foreach (var cityStats in countryStats.Value.OrderBy(x => -x.Value))
                {
                    Console.WriteLine("=>{0}: {1}", cityStats.Key, cityStats.Value);
                }
            }
        }
    }
}