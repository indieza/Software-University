using System;

public class Car
{
    private const double MaxTankCapacity = 160;
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        protected internal set
        {
            this.fuelAmount = Math.Min(value, MaxTankCapacity);

            if (value < 0)
            {
                throw new ArgumentException("Fuel amount cannot be negative number.");
            }
        }
    }

    public void ReduceFuel(int length, double fuelConsumptionPerKm)
    {
        this.FuelAmount = this.FuelAmount - length * fuelConsumptionPerKm;
    }

    public Tyre Tyre
    {
        get { return this.tyre; }
        private set { this.tyre = value; }
    }
}