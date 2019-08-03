namespace MortalEngines.Entities.Models.Machines
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Tank : BaseMachine, ITank
    {
        private const int InitialHealthPoints = 100;
        private const int IncreaseAttackPoints = 40;
        private const int DecreaseDefensePoints = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name,
                  attackPoints - IncreaseAttackPoints,
                  defensePoints + DecreaseDefensePoints,
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
                this.AttackPoints -= IncreaseAttackPoints;
                this.DefensePoints += DecreaseDefensePoints;
            }
            else
            {
                this.DefenseMode = false;
                this.AttackPoints += IncreaseAttackPoints;
                this.DefensePoints -= DecreaseDefensePoints;
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