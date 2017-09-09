internal class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement / sonicFactor)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.sonicFactor;
    }

    public int SonicFactor
    {
        get { return this.sonicFactor; }
        set { this.sonicFactor = value; }
    }
}