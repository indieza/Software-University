namespace MXGP.Models.Races.Contracts
{
    using Riders.Contracts;
    using System.Collections.Generic;

    public interface IRace
    {
        string Name { get; }

        int Laps { get; }

        IReadOnlyCollection<IRider> Riders { get; }

        void AddRider(IRider rider);
    }
}