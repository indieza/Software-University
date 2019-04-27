using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        private string name;
        private Stat stat;
        private Weapon weapon;

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public Stat Stat
        {
            get
            {
                return this.stat;
            }
            private set
            {
                this.stat = value;
            }
        }

        public Weapon Weapon
        {
            get
            {
                return this.weapon;
            }
            private set
            {
                this.weapon = value;
            }
        }

        public int GetTotalPower()
        {
            int sum = 0;
            sum += this.GetWeaponPower() + this.GetStatPower();
            return sum;
        }

        public int GetWeaponPower()
        {
            int sum = 0;
            sum += this.Weapon.Size
               + this.Weapon.Solidity
               + this.Weapon.Sharpness;

            return sum;
        }

        public int GetStatPower()
        {
            int sum = 0;
            sum += this.Stat.Strength
               + this.Stat.Flexibility
               + this.Stat.Agility
               + this.Stat.Skills
               + this.Stat.Intelligence;

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]"); ;
            sb.AppendLine($"  Weapon Power: [{this.GetWeaponPower()}]");
            sb.AppendLine($"  Stat Power: [{this.GetStatPower()}]");
            return sb.ToString().TrimEnd();
        }
    }
}