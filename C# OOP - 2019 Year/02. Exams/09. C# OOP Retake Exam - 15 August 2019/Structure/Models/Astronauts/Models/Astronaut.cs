namespace SpaceStation.Models.Astronauts.Models
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Utilities.Messages;
    using System;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            if (this.Oxygen - 10 < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= 10;
            }
        }
    }
}