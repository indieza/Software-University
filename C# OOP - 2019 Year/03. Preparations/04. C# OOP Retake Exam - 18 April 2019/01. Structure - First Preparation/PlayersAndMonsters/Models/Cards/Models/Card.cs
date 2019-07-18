
namespace PlayersAndMonsters.Models.Cards.Models
{
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PlayersAndMonsters.Common;

    public class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        public Card(string name, int damagePoints, int healthPoints)
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
                    throw new ArgumentException(ExceptionMessages.NegativeDamagePoints);
                }

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;

          private  set
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