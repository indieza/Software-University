namespace AnimalCentre.Models.Animals
{
    using AnimalCentre.Contracts;
    using AnimalCentre.Models.Contracts;
    using System;

    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public string Name { get; private set; }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < Constants.MinHappinessAndEnergy || value > Constants.MaxHappinessAndEnergy)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                this.energy = value;
            }
        }

        public int Happiness
        {
            get
            {
                return this.happiness;
            }
            set
            {
                if (value < Constants.MinHappinessAndEnergy || value > Constants.MaxHappinessAndEnergy)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                this.happiness = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }

        public override string ToString()
        {
            return "    Animal type: {0} - {1} - Happiness: {2} - Energy: {3}";
        }
    }
}