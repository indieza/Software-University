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

        public int Count
        {
            get
            {
                return this.gladiators.Count;
            }
        }

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            Gladiator item = this.gladiators.FirstOrDefault(g => g.Name == name);
            this.gladiators.Remove(item);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            int maxGladiatorStatPower = 0;

            foreach (var gladiator in gladiators)
            {
                if (maxGladiatorStatPower < gladiator.GetStatPower())
                {
                    maxGladiatorStatPower = gladiator.GetStatPower();
                }
            }

            Gladiator currentGladiator = gladiators.FirstOrDefault(x => x.GetStatPower() == maxGladiatorStatPower);
            return currentGladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int maxGladiatorWeaponPower = 0;

            foreach (var gladiator in gladiators)
            {
                if (maxGladiatorWeaponPower < gladiator.GetWeaponPower())
                {
                    maxGladiatorWeaponPower = gladiator.GetWeaponPower();
                }
            }

            Gladiator currentGladiator = gladiators.FirstOrDefault(x => x.GetWeaponPower() == maxGladiatorWeaponPower);
            return currentGladiator;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int maxGladiatorTotalPower = 0;

            foreach (var gladiator in gladiators)
            {
                if (maxGladiatorTotalPower < gladiator.GetTotalPower())
                {
                    maxGladiatorTotalPower = gladiator.GetTotalPower();
                }
            }

            Gladiator currentGladiator = gladiators.FirstOrDefault(x => x.GetTotalPower() == maxGladiatorTotalPower);
            return currentGladiator;
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}