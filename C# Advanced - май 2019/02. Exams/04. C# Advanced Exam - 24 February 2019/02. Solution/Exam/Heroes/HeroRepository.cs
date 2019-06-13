namespace _03.Heroes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public int Count => this.heroes.Count();

        public void Add(Hero hero)
        {
            this.heroes.Add(hero);
        }

        public void Remove(string name)
        {
            this.heroes.Remove(this.heroes.FirstOrDefault(h => h.Name == name));
        }

        public Hero GetHeroWithHighestStrength()
        {
            int maxStrength = this.heroes.Select(h => h.Item.Strength).Max();
            return this.heroes.FirstOrDefault(h => h.Item.Strength == maxStrength);
        }

        public Hero GetHeroWithHighestAbility()
        {
            int maxAbility = this.heroes.Select(h => h.Item.Ability).Max();
            return this.heroes.FirstOrDefault(h => h.Item.Ability == maxAbility);
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int maxAbility = this.heroes.Select(h => h.Item.Ability).Max();
            return this.heroes.FirstOrDefault(h => h.Item.Ability == maxAbility);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Hero hero in this.heroes)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}