namespace FightingArena
{
    using System.Collections.Generic;
    using System.Linq;

    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }

        public int Count => this.gladiators.Count;

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
            int max = this.gladiators.Max(g => g.GetStatPower());

            return this.gladiators.FirstOrDefault(g => g.GetStatPower() == max);
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int max = this.gladiators.Max(g => g.GetWeaponPower());

            return this.gladiators.FirstOrDefault(g => g.GetWeaponPower() == max);
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int max = this.gladiators.Max(g => g.GetTotalPower());

            return this.gladiators.FirstOrDefault(g => g.GetTotalPower() == max);
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}