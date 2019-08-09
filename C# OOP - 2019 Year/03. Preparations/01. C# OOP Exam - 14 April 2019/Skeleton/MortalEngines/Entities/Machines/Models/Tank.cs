namespace MortalEngines.Entities.Machines.Models
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Tank : BaseMachine, ITank
    {
        private const int InitialHealthPoints = 100;
        private const int InititalAttack = 40;
        private const int InitialDefence = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;
                this.AttackPoints -= InititalAttack;
                this.DefensePoints += InitialDefence;
            }
            else
            {
                this.DefenseMode = false;
                this.AttackPoints += InititalAttack;
                this.DefensePoints -= InitialDefence;
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