namespace ViceCity.Models.Guns.Models
{
    using System;
    using ViceCity.Messages;
    using ViceCity.Models.Guns.Contracts;

    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => this.bulletsBarrel;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCountOfBullets);
                }

                this.bulletsBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => this.totalBullets;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTotalBullets);
                }

                this.totalBullets = value;
            }
        }

        public bool CanFire => this.BulletsPerBarrel > 0;

        public abstract int Fire();
    }
}