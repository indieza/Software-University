namespace MXGP.Models.Riders.Contracts
{
    using Motorcycles.Contracts;

    public interface IRider
    {
        string Name { get; }

        IMotorcycle Motorcycle { get; }

        int NumberOfWins { get; }

        bool CanParticipate { get; }

        void WinRace();

        void AddMotorcycle(IMotorcycle motorcycle);
    }
}