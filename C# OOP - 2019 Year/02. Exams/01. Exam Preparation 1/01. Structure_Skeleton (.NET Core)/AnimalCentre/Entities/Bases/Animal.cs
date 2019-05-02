using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Entities
{
    public class Animal : IAnimal
    {
        private string name;
        private int happines;
        private int energy;
        private int procedureTime;
        private string owner;
        private bool isAdopt;
        private bool isChipped;
        private bool isVaccinated;

        public Animal(string name, int energy, int happines, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happines;
            this.ProcedureTime = procedureTime;
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int Happiness
        {
            get
            {
                return this.happines;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }

                this.happines = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }

                this.energy = value;
            }
        }

        public int ProcedureTime
        {
            get
            {
                return this.procedureTime;
            }
            private set
            {
                this.procedureTime = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            private set
            {
                this.owner = value;
            }
        }

        public bool IsAdopt
        {
            get
            {
                return this.isAdopt;
            }
            private set
            {
                this.isAdopt = value;
            }
        }

        public bool IsChipped
        {
            get
            {
                return this.isChipped;
            }
            private set
            {
                this.isChipped = value;
            }
        }

        public bool IsVaccinated
        {
            get
            {
                return this.isVaccinated;
            }
            private set
            {
                this.isVaccinated = value;
            }
        }
    }
}