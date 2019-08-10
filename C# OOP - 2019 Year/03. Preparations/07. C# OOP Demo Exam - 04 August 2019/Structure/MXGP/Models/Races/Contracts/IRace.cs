namespace MXGP.Models.Races.Contracts
{
    using System.Collections.Generic;

    using Riders.Contracts;

    public interface IRace
    {
        string Name { get; }

        int Laps { get; }

        IReadOnlyCollection<IRider> Riders { get; }

        void AddRider(IRider rider);
    }
}