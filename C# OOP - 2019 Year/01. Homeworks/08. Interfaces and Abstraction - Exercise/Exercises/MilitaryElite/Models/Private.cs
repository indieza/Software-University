namespace MilitaryElite
{
    using System;

    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary
        {
            get => this.salary;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input");
                }

                this.salary = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Salary: {this.Salary:F2}";
        }
    }
}