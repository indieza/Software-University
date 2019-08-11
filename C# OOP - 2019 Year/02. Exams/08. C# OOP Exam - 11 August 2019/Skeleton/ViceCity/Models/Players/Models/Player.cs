namespace ViceCity.Models.Players.Models
{
    using System;
    using ViceCity.Messages;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;
    using ViceCity.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.IsAlive = true;
            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlayerName);
                }

                this.name = value;
            }
        }

        public int LifePoints
        {
            get => this.lifePoints;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerLifePoints);
                }

                this.lifePoints = value;
            }
        }

        public IRepository<IGun> GunRepository { get; private set; }

        public bool IsAlive { get; private set; }

        public void TakeLifePoints(int points)
        {
            if (this.LifePoints - points <= 0)
            {
                this.LifePoints = 0;
                this.IsAlive = false;
            }
            else
            {
                this.LifePoints -= points;
            }
        }
    }
}