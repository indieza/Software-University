using System.Collections.Generic;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(IGun model);

        bool Remove(IGun model);

        IGun Find(string name);
    }
}