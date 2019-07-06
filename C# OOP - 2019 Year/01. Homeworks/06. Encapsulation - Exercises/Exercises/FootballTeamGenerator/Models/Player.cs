namespace FootballTeamGenerator.Models
{
    using FootballTeamGenerator.Constraints;
    using System;

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

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionsMessages.EmptyName);
                }

                this.name = value;
            }
        }

        public Stat Stats
        {
            get => this.stats;
            private set => this.stats = value;
        }

        public double AvarageStat => this.Stats.SumTotalStats() / 5.0;
    }
}