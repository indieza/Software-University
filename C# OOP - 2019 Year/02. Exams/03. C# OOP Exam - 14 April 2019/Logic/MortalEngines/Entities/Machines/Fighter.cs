using MortalEngines.Entities.Contracts;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        private const int fighterHealthPoints = 200;
        private const int attackPointsIncreased = 50;
        private const int defensePointDecreased = 25;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name,
                  attackPoints + attackPointsIncreased,
                  defensePoints - defensePointDecreased,
                  fighterHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= attackPointsIncreased;
                this.DefensePoints += defensePointDecreased;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += attackPointsIncreased;
                this.DefensePoints -= defensePointDecreased;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(this.AggressiveMode == true ? " *Aggressive: ON" : " *Aggressive: OFF");
            return sb.ToString().TrimEnd();
        }
    }
}