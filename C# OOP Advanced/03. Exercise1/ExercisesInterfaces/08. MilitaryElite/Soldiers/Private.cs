namespace MilitaryElite.Entities
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, double salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public double Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:f2}";
        }
    }
}