namespace Heroes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => this.data.Count;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            this.data.Remove(this.data.FirstOrDefault(h => h.Name == name));
        }

        public Hero GetHeroWithHighestStrength()
        {
            int maxStrength = this.data.Max(h => h.Item.Strength);

            return this.data.FirstOrDefault(h => h.Item.Strength == maxStrength);
        }

        public Hero GetHeroWithHighestAbility()
        {
            int maxAbility = this.data.Max(h => h.Item.Ability);

            return this.data.FirstOrDefault(h => h.Item.Ability == maxAbility);
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int maxIntelligence = this.data.Max(h => h.Item.Intelligence);

            return this.data.FirstOrDefault(h => h.Item.Intelligence == maxIntelligence);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.data)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}