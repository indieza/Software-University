using System;
using System.Collections.Generic;
using System.Linq;

internal class GreedyTimes
{
    private static void Main()
    {
        long backCapacity = long.Parse(Console.ReadLine());
        string[] items = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        long allCapacityInTheBack = 0;

        Dictionary<string, Dictionary<string, long>> bag =
            new Dictionary<string, Dictionary<string, long>>
            {
                {"Gold", new Dictionary<string, long>()},
                {"Gem", new Dictionary<string, long>()},
                {"Cash", new Dictionary<string, long>()}
            };

        for (int item = 0; item < items.Length; item += 2)
        {
            string itemType = items[item];
            long itemCapacity = long.Parse(items[item + 1]);

            if (allCapacityInTheBack + itemCapacity > backCapacity)
            {
                continue;
            }

            if (itemType.Equals("Gold", StringComparison.CurrentCultureIgnoreCase))
            {
                if (!bag["Gold"].ContainsKey(itemType))
                {
                    bag["Gold"].Add(itemType, 0);
                }

                bag["Gold"][itemType] += itemCapacity;
                allCapacityInTheBack += itemCapacity;
            }
            else if (itemType.Length == 3)
            {
                long cashCapacity = bag["Cash"].Sum(p => p.Value);
                long gemCapacity = bag["Gem"].Sum(p => p.Value);

                if (cashCapacity + itemCapacity <= gemCapacity)
                {
                    if (!bag["Cash"].ContainsKey(itemType))
                    {
                        bag["Cash"].Add(itemType, 0);
                    }

                    bag["Cash"][itemType] += itemCapacity;
                    allCapacityInTheBack += itemCapacity;
                }
            }
            else if (itemType.Length >= 4 && itemType.EndsWith("Gem", StringComparison.InvariantCultureIgnoreCase))
            {
                long gemCapacity = bag["Gem"].Sum(p => p.Value);
                long goldCapacity = bag["Gold"].Sum(p => p.Value);

                if (gemCapacity + itemCapacity <= goldCapacity)
                {
                    if (!bag["Gem"].ContainsKey(itemType))
                    {
                        bag["Gem"].Add(itemType, 0);
                    }

                    bag["Gem"][itemType] += itemCapacity;
                    allCapacityInTheBack += itemCapacity;
                }
            }
        }

        Print(bag, "Gold");
        Print(bag, "Gem");
        Print(bag, "Cash");
    }

    private static void Print(Dictionary<string, Dictionary<string, long>> bag, string key)
    {
        if (bag[key].Count > 0)
        {
            Console.WriteLine($"<{key}> ${bag[key].Sum(p => p.Value)}");

            Dictionary<string, long> sortedDictionary = bag[key]
                .OrderByDescending(p => p.Key)
                .ThenBy(p => p.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (KeyValuePair<string, long> pair in sortedDictionary)
            {
                Console.WriteLine($"##{pair.Key} - {pair.Value}");
            }
        }
    }
}