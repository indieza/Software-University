namespace MXGP.Repositories.Models
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.races.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            return this.races.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }
    }
}