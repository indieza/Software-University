
namespace PlayersAndMonsters.Models.Players.Models
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PlayersAndMonsters.Common;


    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
           this.CardRepository = cardRepository;
           this.Username = username;
           this.Health = health;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyUsername);
                }

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;

            set
            {
                if (value < Constants.MinHealthPoints)
                {
                    throw new ArgumentException(ExceptionMessages.NegativePlayerHealthPoints);
                }

                this.health = value;
            }
        }

        public bool IsDead { get; private set; }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < Constants.MinDamagePoints)
            {
                throw new ArgumentException(ExceptionMessages.NegativeDamagePoints);
            }

            if (this.Health - damagePoints < 0)
            {
                this.Health = 0;
                this.IsDead = true;
            }
            else
            {
                this.Health -= damagePoints;
            }
        }
    }
}