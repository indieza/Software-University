using System;

public abstract class Provider : AbstractEntities
{
    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
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