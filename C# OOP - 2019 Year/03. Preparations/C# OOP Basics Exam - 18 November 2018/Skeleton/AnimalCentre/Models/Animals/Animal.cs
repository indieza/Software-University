
namespace AnimalCentre.Models.Animals
{
    using AnimalCentre.Constraints;
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;

        protected Animal(string name, int energy, int happiness, int produceTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = produceTime;
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public string Name { get; set; }

        public int Happiness
        {
            get
            {
                return this.happiness;
            }

            set
            {
                if (value < Constants.MinAnimalHappiness || value > Constants.MaxAnimalHappiness)
                {
                    throw new ArgumentException(ExceptionsMessages.InvalidHappiness);
                }

                this.happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }

            set
            {
                if (value < Constants.MinAnimalEnergy || value > Constants.MaxAnimalEnergy)
                {
                    throw new ArgumentException(ExceptionsMessages.InvalidEnergy);
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated
        {
            get => this.IsVaccinated1;
            set => this.IsVaccinated1 = value;
        }
        public bool IsVaccinated1 { get; set; }

        public override string ToString()
        {
            return "    Animal type: {0} - {1} - Happiness: {2} - Energy: {3}";
        }
    }
}