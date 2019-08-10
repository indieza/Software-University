namespace MortalEngines.Entities.Machines.Models
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Fighter : BaseMachine, IFighter
    {
        private const int InitialHealthPoints = 200;
        private const int InititalAttack = 50;
        private const int InitialDefence = 25;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += InititalAttack;
                this.DefensePoints -= InitialDefence;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= InititalAttack;
                this.DefensePoints += InitialDefence;
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