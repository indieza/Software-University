using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;
        private int count;

        public HeroRepository()
        {
            this.Data = new List<Hero>();
        }

        public List<Hero> Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
            set
            {
                this.count = value;
            }
        }

        public void Add(Hero hero)
        {
            data.Add(new Hero(hero.Name, hero.Level, hero.Item));
        }

        public void Remove(string name)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Name == name)
                {
                    data.RemoveAt(i);
                }
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero h = data.OrderByDescending(p => p.Item.Strength).FirstOrDefault();
            return h;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero h = data.OrderByDescending(p => p.Item.Ability).FirstOrDefault();
            return h;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero h = data.OrderByDescending(p => p.Item.Intelligence).FirstOrDefault();
            return h;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}