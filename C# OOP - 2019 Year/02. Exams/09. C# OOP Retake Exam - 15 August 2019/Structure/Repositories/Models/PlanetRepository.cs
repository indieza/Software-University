namespace SpaceStation.Repositories.Models
{
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return this.models.Remove(model);
        }
    }
}