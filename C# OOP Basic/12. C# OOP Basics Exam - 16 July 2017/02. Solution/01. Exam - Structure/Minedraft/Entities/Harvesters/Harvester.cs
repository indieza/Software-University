using System;

public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Id
    {
        get { return this.id; }
        protected set { this.id = value; }
    }

    public double OreOutput
    {
        get { return this.oreOutput; }

        protected set
        {
            if (value < Constants.ZeroCheck)
            {
                throw new ArgumentException(string.Format(PrintConstants.HarvesterNotRegisteredExeption, nameof(this.OreOutput)));
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }

        protected set
        {
            if (value < Constants.ZeroCheck || value > Constants.HavresterMaxEnergyRequirement)
            {
                throw new ArgumentException(string.Format(PrintConstants.HarvesterNotRegisteredExeption, nameof(this.EnergyRequirement)));
            }

            this.energyRequirement = value;
        }
    }
}