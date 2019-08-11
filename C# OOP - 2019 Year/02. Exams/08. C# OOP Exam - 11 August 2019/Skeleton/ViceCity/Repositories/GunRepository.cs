namespace ViceCity.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Repositories.Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.guns.AsReadOnly();

        public void Add(IGun model)
        {
            if (!this.guns.Any(g => g.Name == model.Name))
            {
                this.guns.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return this.guns.FirstOrDefault(g => g.Name == name);
        }

        public bool Remove(IGun model)
        {
            return this.guns.Remove(model);
        }
    }
}