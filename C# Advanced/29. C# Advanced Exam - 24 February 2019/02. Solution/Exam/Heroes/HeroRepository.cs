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

        private int Count => this.Data.Count;

        private void Add(Hero hero)
        {
        }
        private void Remove(string name)
        {
        }

        private Hero GetHeroWithHighestStrength()
        {
            return data[0];
        }
        private Hero GetHeroWithHighestAbility()
        {
            return data[0];
        }
        private Hero GetHeroWithHighestIntelligence()
        {
            return data[0];
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
