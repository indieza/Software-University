
namespace FootballTeamGenerator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Player
    {
        private string name;
        private Stat stats;

        public Player(string name, Stat stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public Stat Stats
        {
            get => this.stats;
            private set => this.stats = value;
        }
    }
}