public interface IProvider : IEntity
{
    double EnergyOutput { get; }

    void Repair(double val);
}