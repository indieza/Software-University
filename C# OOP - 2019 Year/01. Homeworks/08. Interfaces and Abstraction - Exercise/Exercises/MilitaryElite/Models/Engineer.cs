namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : Private, IEngineer
    {
        private readonly List<IRepair> repairs;
        private string corps;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => this.repairs.AsReadOnly();

        public string Corps
        {
            get => this.corps;

            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new Exception("Invalid input");
                }

                this.corps = value;
            }
        }

        public void AddRepair(Repair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder engineerInfo = new StringBuilder();

            engineerInfo.AppendLine($"Corps: {this.corps}");
            engineerInfo.AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                engineerInfo.AppendLine("  " + repair);
            }

            return base.ToString() + Environment.NewLine + engineerInfo.ToString().TrimEnd();
        }
    }
}