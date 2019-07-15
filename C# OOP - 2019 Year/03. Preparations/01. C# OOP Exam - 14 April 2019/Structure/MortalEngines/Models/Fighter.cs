namespace MortalEngines.Models
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;
        private const double IncreaseAttackPoints = 50;
        private const double IncreaseDefensePoints = 25;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name,
                  attackPoints + IncreaseAttackPoints,
                  defensePoints - IncreaseDefensePoints,
                  InitialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= IncreaseAttackPoints;
                this.DefensePoints += IncreaseDefensePoints;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += IncreaseAttackPoints;
                this.DefensePoints -= IncreaseDefensePoints;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Aggressive: {(this.AggressiveMode == true ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}