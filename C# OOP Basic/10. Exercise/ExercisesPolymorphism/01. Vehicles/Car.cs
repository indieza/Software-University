using System;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumptionlitersPerKm) : base(fuelQuantity, fuelConsumptionlitersPerKm)
    {
    }

    public double RefuelCar(double fuel)
    {
        return base.FuelQuantity + fuel;
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