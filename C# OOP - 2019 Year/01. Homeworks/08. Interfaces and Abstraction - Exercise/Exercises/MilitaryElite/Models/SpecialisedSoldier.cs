namespace MilitaryElite
{
    using System;
    using System.Text;

    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corp;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }

        public string Corp
        {
            get => this.corp;

            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid corp!");
                }

                this.corp = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corp}");

            return sb.ToString().TrimEnd();
        }
    }
}