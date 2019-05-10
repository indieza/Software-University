using MortalEngines.Entities.Contracts;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine, ITank
    {
        private const int tankHealthPoints = 100;
        private const int attackPointsDecreased = 40;
        private const int defensePointIncreased = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints - attackPointsDecreased, defensePoints + defensePointIncreased, tankHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.AttackPoints += attackPointsDecreased;
                this.DefensePoints -= defensePointIncreased;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= attackPointsDecreased;
                this.DefensePoints += defensePointIncreased;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(this.DefenseMode == true ? " *Defense: ON" : " *Defense: OFF");
            return sb.ToString().TrimEnd();
        }
    }
}