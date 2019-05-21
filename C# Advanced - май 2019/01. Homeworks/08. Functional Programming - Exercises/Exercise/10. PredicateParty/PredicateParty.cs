using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    public class PredicateParty
    {
        private static void Main()
        {
            List<string> guests = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] commandItems = command
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string condition = commandItems[2];

                Func<string, bool> filter;

                switch (commandItems[0])
                {
                    case "Remove" when commandItems[1] == "StartsWith":
                        filter = x => !x.StartsWith(condition);
                        break;

                    case "Remove" when commandItems[1] == "EndsWith":
                        filter = x => !x.EndsWith(condition);
                        break;

                    case "Remove":
                        filter = x => x.Length != int.Parse(condition);
                        break;

                    case "Double" when commandItems[1] == "StartsWith":
                        filter = x => x.StartsWith(condition);
                        break;

                    case "Double" when commandItems[1] == "EndsWith":
                        filter = x => x.EndsWith(condition);
                        break;

                    default:
                        filter = x => x.Length == int.Parse(condition);
                        break;
                }

                if (commandItems[0] == "Remove")
                {
                    guests = guests.Where(filter).ToList();
                }
                else
                {
                    List<string> tempList = guests.Where(filter).ToList();

                    foreach (var name in tempList)
                    {
                        var index = guests.IndexOf(name);
                        guests.Insert(index, name);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(guests.Any()
                ? $"{string.Join(", ", guests)} are going to the party!"
                : "Nobody is going to the party!");
        }
    }
}