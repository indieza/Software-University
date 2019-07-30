using System;

using Service.Models.Contracts;

namespace Service.Models.Parts
{
    public abstract class Part : IPart
    {
        private string name;
        private decimal cost;

        public Part(string name, decimal cost, bool isBroken)
        {
            this.Name = name;
            this.Cost = cost;
            this.IsBroken = isBroken;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Part name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Part cost cannot be zero or negative!");
                }

                this.cost = value;
            }
        }

        public bool IsBroken { get; private set; }

        public void Repair()
        {
            this.IsBroken = false;
        }

        public string Report()
        {
            return $"{this.Name} - {this.Cost:f2}$" + Environment.NewLine + 
                $"Broken: {this.IsBroken}";
        }
    }
}
