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
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                this.name = value;
            }
        }

        public int Count => this.gladiators.Count();

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            this.gladiators.Remove(this.gladiators.FirstOrDefault(g => g.Name == name));
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            int maxStat = int.MinValue;

            foreach (var currentGladiator in this.gladiators)
            {
                if (maxStat < currentGladiator.GetStatPower())
                {
                    maxStat = currentGladiator.GetStatPower();
                }
            }

            Gladiator gladiator = this.gladiators.FirstOrDefault(g => g.GetStatPower() == maxStat);

            return gladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int maxWeapon = int.MinValue;

            foreach (var currentGladiator in this.gladiators)
            {
                if (maxWeapon < currentGladiator.GetWeaponPower())
                {
                    maxWeapon = currentGladiator.GetWeaponPower();
                }
            }

            Gladiator gladiator = this.gladiators.FirstOrDefault(g => g.GetWeaponPower() == maxWeapon);

            return gladiator;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int maxPower = int.MinValue;

            foreach (var currentGladiator in this.gladiators)
            {
                if (maxPower < currentGladiator.GetTotalPower())
                {
                    maxPower = currentGladiator.GetTotalPower();
                }
            }

            Gladiator gladiator = this.gladiators.FirstOrDefault(g => g.GetTotalPower() == maxPower);

            return gladiator;
        }

        public override string ToString()
        {
            return ($"[{this.Name}] - [{this.Count}] gladiators are participating.").TrimEnd();
        }
    }
}