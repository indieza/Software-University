using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservation
{
    public class PartyReservationFilterModule
    {
        private static void Main()
        {
            List<string> people = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, List<string>> filters = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();

            while (line != "Print")
            {
                string[] commandItems = line.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                string command = commandItems[0];
                string filterType = commandItems[1];
                string parameter = commandItems[2];

                if (command == "Add filter")
                {
                    if (!filters.ContainsKey(filterType))
                    {
                        filters.Add(filterType, new List<string>());
                    }
                    if (!filters[filterType].Contains(parameter))
                    {
                        filters[filterType].Add(parameter);
                    }
                }
                else if (command == "Remove filter")
                {
                    if (filters.ContainsKey(filterType))
                    {
                        filters[filterType].Remove(parameter);
                    }
                }

                line = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                if (filter.Key == "Length")
                {
                    foreach (var condition in filter.Value)
                    {
                        people = people.Where(p => p.Length != int.Parse(condition)).ToList();
                    }
                }
                else if (filter.Key == "Starts with")
                {
                    foreach (var condition in filter.Value)
                    {
                        people = people.Where(p => !p.StartsWith(condition)).ToList();
                    }
                }
                else if (filter.Key == "Ends with")
                {
                    foreach (var condition in filter.Value)
                    {
                        people = people.Where(p => !p.EndsWith(condition)).ToList();
                    }
                }
                else if (filter.Key == "Contains")
                {
                    foreach (var condition in filter.Value)
                    {
                        people = people.Where(p => !p.Contains(condition)).ToList();
                    }
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }
    }
}