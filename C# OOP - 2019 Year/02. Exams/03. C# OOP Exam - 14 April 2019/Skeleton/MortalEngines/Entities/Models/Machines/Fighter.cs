namespace MortalEngines.Entities.Models.Machines
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Fighter : BaseMachine, IFighter
    {
        private const int InitialHealthPoints = 200;
        private const int InitialAttack = 50;
        private const int InitialDefnse = 25;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name,
                  attackPoints + InitialAttack,
                  defensePoints - InitialDefnse,
                  InitialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += InitialAttack;
                this.DefensePoints -= InitialDefnse;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= InitialAttack;
                this.DefensePoints += InitialDefnse;
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