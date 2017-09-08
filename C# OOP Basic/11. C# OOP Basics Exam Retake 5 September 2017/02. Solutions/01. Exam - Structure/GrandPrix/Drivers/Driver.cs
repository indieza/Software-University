using System;

public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    private double speed;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public double TotalTime
    {
        get { return this.totalTime; }
        protected set { this.totalTime = value; }
    }

    public Car Car
    {
        get { return this.car; }

        protected set
        {
            if (value.Tyre.Degradation < 0)
            {
                throw new ArgumentException("Degradation value cannot be negative number.");
            }

            this.car = value;
        }
    }

    public virtual double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        protected set { this.fuelConsumptionPerKm = value; }
    }

    public virtual double Speed
    {
        get { return this.speed; }

        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Speed value cannot be negative number.");
            }

            this.speed = (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
        }
    }
}