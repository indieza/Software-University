namespace MilitaryElite
{
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

        public IReadOnlyCollection<IPrivate> Privates => this.privates.AsReadOnly();

        public void AddPrivate(Private privateSoldier)
        {
            this.privates.Add(privateSoldier);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (Private person in this.Privates)
            {
                sb.AppendLine("  " + person.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}