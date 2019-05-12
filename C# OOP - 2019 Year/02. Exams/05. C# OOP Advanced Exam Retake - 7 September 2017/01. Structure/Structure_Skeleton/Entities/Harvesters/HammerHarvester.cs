public class HammerHarvester : Harvester
{
    private const int EnergyRequirementMultiplier = 2;
    private const int OreOutputMultiplier = 3;

    public HammerHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *= OreOutputMultiplier;
        this.EnergyRequirement *= EnergyRequirementMultiplier;
    }
}