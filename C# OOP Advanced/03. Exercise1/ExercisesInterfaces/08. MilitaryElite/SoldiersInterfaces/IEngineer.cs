using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IList<IRepair> Parts { get; }
    }
}