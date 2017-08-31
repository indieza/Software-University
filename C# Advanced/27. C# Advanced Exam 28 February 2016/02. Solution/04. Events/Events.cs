using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

internal class Events
{
    private static DateTime eventTime;

    private static void Main()
    {
        Regex pattern = new Regex(@"^#([A-Za-z]+):\s*@([A-Za-z]+)\s*(\d+:\d+)$");

        int n = int.Parse(Console.ReadLine());

        var data = new SortedDictionary<string, SortedDictionary<string, List<DateTime>>>();

        for (int i = 0; i < n; i++)
        {
            Match match = pattern.Match(Console.ReadLine());

            if (match.Success && IsValidDate(match.Groups[3].Value))
            {
                string person = match.Groups[1].Value;
                string location = match.Groups[2].Value;

                if (!data.ContainsKey(location))
                {
                    data[location] = new SortedDictionary<string, List<DateTime>>();
                }
                if (!data[location].ContainsKey(person))
                {
                    data[location][person] = new List<DateTime>();
                }

                data[location][person].Add(eventTime);
            }
        }

        string[] locations = Console.ReadLine().Split(',');

        foreach (var pair in data)
        {
            if (locations.Contains(pair.Key))
            {
                Console.WriteLine(pair.Key + ":");
                int lineNumber = 1;

                foreach (var personData in pair.Value)
                {
                    var formattedEventTimes = personData.Value
                        .OrderBy(v => v)
                        .Select(v => v.ToString("HH:mm"));

                    Console.WriteLine($"{lineNumber++}. {personData.Key} -> {string.Join(", ", formattedEventTimes)}");
                }
            }
        }
    }

    private static bool IsValidDate(string d)
    {
        return DateTime.TryParse(d, out eventTime);
    }
}