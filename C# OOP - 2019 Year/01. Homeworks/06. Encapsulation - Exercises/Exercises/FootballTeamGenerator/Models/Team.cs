namespace FootballTeamGenerator.Models
{
    using FootballTeamGenerator.Constraints;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionsMessages.EmptyName);
                }

                this.name = value;
            }
        }

        public IReadOnlyCollection<Player> Players => this.players.AsReadOnly();

        public void AddPlayer(Player player)
        {
            if (player != null)
            {
                this.players.Add(player);
            }
        }

        public void RemovePlayer(string playerName)
        {
            if (this.players.All(p => p.Name != playerName))
            {
                throw new ArgumentException(
                    string.Format(ExceptionsMessages.PlayeIsNotInTheTeam, playerName, this.Name));
            }
            else
            {
                this.players.RemoveAll(p => p.Name == playerName);
            }
        }
    }
}