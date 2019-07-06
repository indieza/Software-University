namespace FootballTeamGenerator.Core
{
    using FootballTeamGenerator.Constraints;
    using FootballTeamGenerator.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly Dictionary<string, Team> teams;

        public Engine()
        {
            this.teams = new Dictionary<string, Team>();
        }

        public void Run()
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                try
                {
                    string[] commandItems = inputLine.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    string command = commandItems[0];
                    string teamName = commandItems[1];

                    if (command != "Team" && !teams.ContainsKey(teamName))
                    {
                        throw new ArgumentException(string.Format(ExceptionsMessages.TeamDoesNotExist, teamName));
                    }

                    switch (command)
                    {
                        case "Team":
                            {
                                Team team = new Team(teamName);

                                if (!this.teams.ContainsKey(teamName) && team != null)
                                {
                                    this.teams.Add(teamName, new Team(teamName));
                                }
                            }
                            break;

                        case "Add":
                            {
                                string name = commandItems[2];
                                int endurance = int.Parse(commandItems[3]);
                                int sprint = int.Parse(commandItems[4]);
                                int dribble = int.Parse(commandItems[5]);
                                int passing = int.Parse(commandItems[6]);
                                int shooting = int.Parse(commandItems[7]);

                                Stat stat = new Stat(endurance, sprint, dribble, passing, shooting);
                                Player player = new Player(name, stat);
                                this.teams[teamName].AddPlayer(player);
                            }
                            break;

                        case "Remove":
                            {
                                string playerName = commandItems[2];
                                this.teams[teamName].RemovePlayer(playerName);
                            }
                            break;

                        case "Rating":
                            {
                                if (!this.teams.ContainsKey(teamName))
                                {
                                    throw new ArgumentException(ExceptionsMessages.TeamDoesNotExist, teamName);
                                }

                                double totalStat = this.teams[teamName].Players.Sum(p => p.AvarageStat);

                                Console.WriteLine($"{teamName} - {Math.Round(totalStat)}");
                            }
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}