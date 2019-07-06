
namespace FootballTeamGenerator.Core
{
    using FootballTeamGenerator.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class Engine
    {
        private Dictionary<string, Team> teams;

        public Engine()
        {
            this.teams = new Dictionary<string, Team>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] commandItems = command.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                    switch (commandItems[0])
                    {
                        case "Team":
                            {
                                string name = commandItems[1];
                                Team team = new Team(name);

                                if (!this.teams.ContainsKey(name) && team != null)
                                {
                                    this.teams.Add(name, new Team(name));
                                }
                            }
                            break;
                        case "Add":
                            {
                                string teamName = commandItems[1];
                                string name = commandItems[2];
                                int endurance = int.Parse(commandItems[3]);
                                int sprint = int.Parse(commandItems[4]);
                                int dribble = int.Parse(commandItems[5]);
                                int passing = int.Parse(commandItems[6]);
                                int shooting = int.Parse(commandItems[7]);

                                Stat stat = new Stat(endurance, sprint, dribble, passing, shooting);
                                Player player = new Player(name, stat);

                                if (!this.teams.ContainsKey(teamName))
                                {
                                    throw new ArgumentException($"Team {teamName} does not exist.");
                                }

                                this.teams[teamName].AddPlayer(player);
                            }
                            break;
                        case "Remove":
                            {
                                string teamName = commandItems[1];
                                string playerName = commandItems[2];
                                this.teams[teamName].RemovePlayer(playerName);
                            }
                            break;
                        case "Rating":
                            {
                                string teamName = commandItems[1];

                                if (!this.teams.ContainsKey(teamName))
                                {
                                    throw new ArgumentException("Team {teamName} does not exist.");
                                }

                                int totalStat = this.teams[teamName].Players.Sum(p => p.Stats.SumTotalStats());

                                Console.WriteLine($"{teamName} - {Math.Round(totalStat / 5.0m)}");
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

                command = Console.ReadLine();

            }
        }
    }
}