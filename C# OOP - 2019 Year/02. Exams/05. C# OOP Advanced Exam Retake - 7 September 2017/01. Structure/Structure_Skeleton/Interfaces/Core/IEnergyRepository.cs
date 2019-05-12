public interface IEnergyRepository
{
    double EnergyStored { get; }

    bool TakeEnergy(double energyNeeded);

    void StoreEnergy(double energy);
}