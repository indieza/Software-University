using System.Collections.Generic;
using System.Linq;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;
        private string name;

        public Arena(string name)
        {
            this.gladiators = new List<Gladiator>();
            this.Name = name;
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

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(new Gladiator(gladiator.Name, gladiator.Stat, gladiator.Weapon));
        }

        public void Remove(string name)
        {
            var item = this.gladiators.FirstOrDefault(g => g.Name == name);
            this.gladiators.Remove(item);
        }

        public int Count
        {
            get
            {
                return this.gladiators.Count;
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            int maxStat = gladiators.Max(g => g.GetStatPower());
            return gladiators.FirstOrDefault(g => g.GetStatPower() == maxStat);
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int maxWeapon = gladiators.Max(g => g.GetWeaponPower());
            return gladiators.FirstOrDefault(g => g.GetWeaponPower() == maxWeapon);
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int maxTotal = gladiators.Max(g => g.GetTotalPower());
            return gladiators.FirstOrDefault(g => g.GetTotalPower() == maxTotal);
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}