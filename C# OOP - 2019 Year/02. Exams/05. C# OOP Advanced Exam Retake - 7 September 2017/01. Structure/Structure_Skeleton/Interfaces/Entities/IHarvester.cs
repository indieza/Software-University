public interface IHarvester : IEntity
{
    double OreOutput { get; }

    double EnergyRequirement { get; }
}