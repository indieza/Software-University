using System;

public abstract class Provider
{
    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get { return this.id; }
        protected set { this.id = value; }
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }

        protected set
        {
            if (value < Constants.ZeroCheck || value > Constants.ProviderMaxEnergyOutput)
            {
                throw new ArgumentException(string.Format(PrintConstants.ProviderNotRegisteredExeption, nameof(this.EnergyOutput)));
            }

            this.energyOutput = value;
        }
    }
}