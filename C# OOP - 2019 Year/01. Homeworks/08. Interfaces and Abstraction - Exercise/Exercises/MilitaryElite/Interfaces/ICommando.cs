namespace MilitaryElite
{
    using System.Collections.Generic;

    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}