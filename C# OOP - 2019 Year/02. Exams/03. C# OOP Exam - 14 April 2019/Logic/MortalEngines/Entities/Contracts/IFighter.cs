namespace MortalEngines.Entities.Contracts
{
    public interface IFighter : IMachine
    {
        bool AggressiveMode { get; }

        void ToggleAggressiveMode();
    }
}