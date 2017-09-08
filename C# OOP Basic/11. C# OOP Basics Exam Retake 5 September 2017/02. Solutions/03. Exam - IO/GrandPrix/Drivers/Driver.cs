using System;

public abstract class Driver
{
    private Car car;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public string Name { get; protected set; }

    public double TotalTime { get; protected set; }

    public Car Car
    {
        get { return this.car; }

        protected set
        {
            if (value.Tyre.Degradation < 0)
            {
                throw new ArgumentException("Crashed");
            }

            this.car = value;
        }
    }

    public virtual double FuelConsumptionPerKm { get; protected set; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public void IncreaseTotalTime(int length)
    {
        this.TotalTime += 60 / (length / this.Speed);
    }

    public void ReduceFuelAmount(int length)
    {
        this.Car.ReduceFuel(length, this.FuelConsumptionPerKm);
    }

    public void IncreaseTotalTimeForBoxCommand(double time)
    {
        this.TotalTime += time;
    }

    public void DecreaseTotalTimeOvertake(double interval)
    {
        this.TotalTime -= interval;
    }

    public void IncreaseTotalTimeOvertaken(double interval)
    {
        this.TotalTime += interval;
    }
}