using System;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumptionlitersPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionlitersPerKm, tankCapacity)
    {
    }

    public double RefuelCar(double fuel)
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

    public double DriveCar(double distance)
    {
        double leftFuel = base.FuelQuantity - distance * (base.FuelConsumptionlitersPerKm + 0.9d);

        if (leftFuel < 0)
        {
            Console.WriteLine("Car needs refueling");
            leftFuel = base.FuelQuantity;
        }
        else
        {
            Console.WriteLine($"Car travelled {distance} km");
        }

        return leftFuel;
    }

    public override string ToString()
    {
        return $"Car: {base.FuelQuantity:F2}";
    }
}