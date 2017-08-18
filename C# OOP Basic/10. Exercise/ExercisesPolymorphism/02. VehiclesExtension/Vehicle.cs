public class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionlitersPerKm;
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumptionlitersPerKm, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionlitersPerKm = fuelConsumptionlitersPerKm;
        this.TankCapacity = tankCapacity;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set { this.fuelQuantity = value; }
    }

    public double FuelConsumptionlitersPerKm
    {
        get { return this.fuelConsumptionlitersPerKm; }
        set { this.fuelConsumptionlitersPerKm = value; }
    }

    public double TankCapacity
    {
        get { return this.tankCapacity; }
        set { this.tankCapacity = value; }
    }
}