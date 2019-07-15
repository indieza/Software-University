namespace MortalEngines.Entities.Models
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Tank : BaseMachine, ITank
    {
        private const int InitialHealthPoints = 100;
        private const int InitialAttackPoints = 40;
        private const int InitialDefensePoints = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name,
                  attackPoints - InitialAttackPoints,
                  defensePoints + InitialDefensePoints,
                  InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;
                this.AttackPoints -= InitialAttackPoints;
                this.DefensePoints += InitialDefensePoints;
            }
            else
            {
                this.DefenseMode = false;
                this.AttackPoints += InitialAttackPoints;
                this.DefensePoints -= InitialDefensePoints;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Defense: {(this.DefenseMode == true ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}