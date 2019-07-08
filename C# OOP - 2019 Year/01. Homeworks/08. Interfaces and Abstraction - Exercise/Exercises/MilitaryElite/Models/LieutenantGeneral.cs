namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<Private> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
        }

        public IReadOnlyCollection<Private> Privates => this.privates.AsReadOnly();

        public void AddPrivate(Private currentPrivate)
        {
            this.privates.Add(currentPrivate);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Privates:");

            foreach (var currentPrivate in this.privates)
            {
                sb.AppendLine("  " + currentPrivate);
            }

            return base.ToString() + Environment.NewLine + sb.ToString().TrimEnd();
        }
    }
}