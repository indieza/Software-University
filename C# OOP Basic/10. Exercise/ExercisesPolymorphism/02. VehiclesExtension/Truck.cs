using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionlitersPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionlitersPerKm, tankCapacity)
    {
    }

    public double RefuelTruck(double fuel)
    {
        if (fuel <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            fuel = 0;
        }

        return base.FuelQuantity + fuel * 0.95d;
    }

    public double DriveTruck(double distance)
    {
        double leftFuel = base.FuelQuantity - distance * (base.FuelConsumptionlitersPerKm + 1.6d);

        if (leftFuel < 0)
        {
            Console.WriteLine("Truck needs refueling");
            leftFuel = base.FuelQuantity;
        }
        else
        {
            Console.WriteLine($"Truck travelled {distance} km");
        }

        return leftFuel;
    }

    public override string ToString()
    {
        return $"Truck: {base.FuelQuantity:F2}";
    }
}