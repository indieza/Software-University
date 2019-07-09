namespace MilitaryElite
{
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary, corp)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => this.repairs.AsReadOnly();

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine("Repairs:");

            foreach (Repair repair in this.repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}