namespace PlayersAndMonsters.Models.Cards.Models
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;

    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyCardName);
                }

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get => this.damagePoints;

            set
            {
                if (value < Constants.MinDamagePoints)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeCardDamagePoints);
                }

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;

            private set
            {
                if (value < Constants.MinHealthPoints)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeCardHealthPoints);
                }

                this.healthPoints = value;
            }
        }
    }
}