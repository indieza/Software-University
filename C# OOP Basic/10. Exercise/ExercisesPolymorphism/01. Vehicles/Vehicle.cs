public class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionlitersPerKm;

    public Vehicle(double fuelQuantity, double fuelConsumptionlitersPerKm)
    {
        this.fuelQuantity = fuelQuantity;
        this.fuelConsumptionlitersPerKm = fuelConsumptionlitersPerKm;
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
}