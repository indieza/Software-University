using System;
using System.Collections.Generic;
using System.Linq;

internal class ChampionsLeague
{
    private static readonly IDictionary<string, int> WinStatistics = new Dictionary<string, int>();
    private static readonly IDictionary<string, ISet<string>> OpponentStatistics = new Dictionary<string, ISet<string>>();

    private static void Main()
    {
        string line;
        while ((line = Console.ReadLine()) != "stop")
        {
            string[] lineArgs = line.Split('|').Select(s => s.Trim()).ToArray();
            string firstTeam = lineArgs[0];
            string secondTeam = lineArgs[1];

            string winningTeam = FindWinner(firstTeam, secondTeam, lineArgs[2], lineArgs[3]);
            AddTeamToWinStatistics(firstTeam, firstTeam == winningTeam);
            AddTeamToWinStatistics(secondTeam, secondTeam == winningTeam);

            AddOpponent(firstTeam, secondTeam);
            AddOpponent(secondTeam, firstTeam);
        }

        foreach (var kvPair in WinStatistics.OrderByDescending(e => e.Value).ThenBy(e => e.Key))
        {
            Console.WriteLine(kvPair.Key);
            Console.WriteLine("- Wins: " + kvPair.Value);
            Console.WriteLine("- Opponents: " + string.Join(", ", OpponentStatistics[kvPair.Key]));
        }
    }

    private static string FindWinner(string firstTeam, string secondTeam, string firstScore, string secondScore)
    {
        int[] firstMatchGoals = GetGoals(firstScore);
        int[] secondMatchGoals = GetGoals(secondScore);

        int firstTeamGoals = firstMatchGoals[0] + secondMatchGoals[1];
        int secondTeamGoals = firstMatchGoals[1] + secondMatchGoals[0];

        if (firstTeamGoals == secondTeamGoals)
        {
            return firstMatchGoals[1] < secondMatchGoals[1] ? firstTeam : secondTeam;
        }

        return firstTeamGoals > secondTeamGoals ? firstTeam : secondTeam;
    }

    private static int[] GetGoals(string score)
    {
        return score.Split(':').Select(int.Parse).ToArray();
    }

    private static void AddTeamToWinStatistics(string team, bool isWinner)
    {
        if (!WinStatistics.ContainsKey(team))
        {
            WinStatistics[team] = 0;
        }

        if (isWinner)
        {
            WinStatistics[team]++;
        }
    }

    private static void AddOpponent(string team, string opponent)
    {
        if (!OpponentStatistics.ContainsKey(team))
        {
            OpponentStatistics[team] = new SortedSet<string>();
        }

        OpponentStatistics[team].Add(opponent);
    }
}