namespace MortalEngines.Models
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;
        private const double IncreaseAttackPoints = 40;
        private const double IncreaseDefensePoints = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.AttackPoints += IncreaseAttackPoints;
                this.DefensePoints -= IncreaseDefensePoints;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= IncreaseAttackPoints;
                this.DefensePoints += IncreaseDefensePoints;
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