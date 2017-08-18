using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumptionlitersPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionlitersPerKm, tankCapacity)
    {
    }

    public double DriveBus(double distance)
    {
        double leftFuel = base.FuelQuantity - distance * (base.FuelConsumptionlitersPerKm + 1.4d);

        if (leftFuel <= 0)
        {
            Console.WriteLine("Bus needs refueling");
            leftFuel = base.FuelQuantity;
        }
        else
        {
            Console.WriteLine($"Bus travelled {distance} km");
        }

        return leftFuel;
    }

    public double RefuelBus(double fuel)
    {
        double fuelToAdd = base.FuelQuantity + fuel;

        if (fuel <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            fuelToAdd = base.FuelQuantity;
        }
        if (fuelToAdd > base.TankCapacity)
        {
            Console.WriteLine("Cannot fit fuel in tank");
            fuelToAdd = base.FuelQuantity;
        }

        return fuelToAdd;
    }

    public double DriveEmpty(double distance)
    {
        double leftFuel = base.FuelQuantity - distance * base.FuelConsumptionlitersPerKm;

        if (leftFuel < 0)
        {
            Console.WriteLine("Bus needs refueling");
            leftFuel = base.FuelQuantity;
        }
        else
        {
            Console.WriteLine($"Bus travelled {distance} km");
        }

        return leftFuel;
    }

    public override string ToString()
    {
        return $"Bus: {base.FuelQuantity:F2}";
    }
}