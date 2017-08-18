using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando : ISpecialisedSoldier
    {
        IList<IMission> Missions { get; }

        void CompleteMission();
    }
}