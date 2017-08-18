using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Entities
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, double salary, string corps, IList<IRepair> parts)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Parts = parts;
        }

        public IList<IRepair> Parts { get; }

        public override string ToString()
        {
            var sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
            sb.AppendLine("Repairs:");
            sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", this.Parts)}");
            return sb.ToString().Trim();
        }
    }
}