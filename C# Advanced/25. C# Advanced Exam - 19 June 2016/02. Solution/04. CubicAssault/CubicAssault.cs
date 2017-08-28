using System;
using System.Collections.Generic;
using System.Linq;

internal class CubicAssault
{
    private static void Main()
    {
        string line = Console.ReadLine();
        Dictionary<string, Dictionary<string, long>> meteors = new Dictionary<string, Dictionary<string, long>>();
        List<string> meteorNames = new List<string>()
        {
            "Green",
            "Red",
            "Black"
        };

        while (line != "Count em all")
        {
            string[] items = line.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

            string regionName = items[0];
            string meteorType = items[1];
            long count = long.Parse(items[2]);

            if (!meteors.ContainsKey(regionName))
            {
                meteors[regionName] = new Dictionary<string, long>()
                {
                    {"Green", 0},
                    {"Red", 0},
                    {"Black", 0}
                };
            }

            meteors[regionName][meteorType] += count;

            for (int i = 0; i < meteorNames.Count - 1; i++)
            {
                long currentnumber = meteors[regionName][meteorNames[i]] / 1000000;

                if (currentnumber > 0)
                {
                    meteors[regionName][meteorNames[i + 1]] += currentnumber;
                    meteors[regionName][meteorNames[i]] %= 1000000;
                }
            }

            line = Console.ReadLine();
        }

        var orderedMeteors = meteors.OrderByDescending(meteor => meteor.Value["Black"])
            .ThenBy(meteor => meteor.Key.Length).ThenBy(meteor => meteor.Key)
            .ToDictionary(meteor => meteor.Key, meteor => meteor.Value);

        foreach (var orderedMeteor in orderedMeteors)
        {
            Console.WriteLine(orderedMeteor.Key);

            foreach (var pair in orderedMeteor.Value.OrderByDescending(meteor => meteor.Value).ThenBy(meteor => meteor.Key))
            {
                Console.WriteLine($"-> {pair.Key} : {pair.Value}");
            }
        }
    }
}