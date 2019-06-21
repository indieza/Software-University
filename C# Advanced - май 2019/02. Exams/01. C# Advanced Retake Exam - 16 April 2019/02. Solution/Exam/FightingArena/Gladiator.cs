namespace FightingArena
{
    using System.Text;

    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            return this.GetWeaponPower() + this.GetStatPower();
        }

        public int GetWeaponPower()
        {
            return this.Weapon.Size + this.Weapon.Solidity + this.Weapon.Sharpness;
        }

        public int GetStatPower()
        {
            return this.Stat.Strength
                + this.Stat.Flexibility
                + this.Stat.Agility
                + this.Stat.Skills
                + this.Stat.Intelligence;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]");
            sb.AppendLine($"  Weapon Power: [{this.GetWeaponPower()}]");
            sb.AppendLine($"  Stat Power: [{this.GetStatPower()}]");

            return sb.ToString().TrimEnd();
        }
    }
}