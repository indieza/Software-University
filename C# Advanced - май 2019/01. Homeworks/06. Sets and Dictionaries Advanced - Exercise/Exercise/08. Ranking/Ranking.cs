using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    public class Ranking
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (line != "end of contests")
            {
                string[] items = line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                string contest = items[0];
                string password = items[1];

                contests.Add(contest, password);

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            Dictionary<string, Dictionary<string, int>> competitors = new Dictionary<string, Dictionary<string, int>>();

            while (line != "end of submissions")
            {
                string[] items = line.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);

                string contest = items[0];
                string password = items[1];
                string username = items[2];
                int points = int.Parse(items[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == password)
                    {
                        if (!competitors.ContainsKey(username))
                        {
                            competitors.Add(username, new Dictionary<string, int>());
                        }
                        if (competitors.ContainsKey(username))
                        {
                            if (competitors[username].ContainsKey(contest))
                            {
                                if (competitors[username][contest] < points)
                                {
                                    competitors[username][contest] = points;
                                }
                            }
                            else
                            {
                                competitors[username].Add(contest, points);
                            }
                        }
                    }
                }

                line = Console.ReadLine();
            }

            string bestCompetitor = FindTheBest(competitors);

            Console.WriteLine(
                $"Best candidate is {bestCompetitor} with total {competitors[bestCompetitor].Sum(p => p.Value)} points.");

            Console.WriteLine("Ranking:");

            foreach (var competitor in competitors.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{competitor.Key}");

                foreach (var competition in competitor.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {competition.Key} -> {competition.Value}");
                }
            }
        }

        private static string FindTheBest(Dictionary<string, Dictionary<string, int>> competitors)
        {
            int maxPoints = -1;
            string name = string.Empty;

            foreach (var competitor in competitors)
            {
                int points = competitor.Value.Sum(c => c.Value);

                if (points > maxPoints)
                {
                    maxPoints = points;
                    name = competitor.Key;
                }
            }

            return name;
        }
    }
}