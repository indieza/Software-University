public class EnduranceDriver : Driver
{
    private const double FuelConsumptionPerKmEnduranceDriver = 1.5;

    public EnduranceDriver(string name, Car car)
        : base(name, car)
    {
    }

    public override double FuelConsumptionPerKm => FuelConsumptionPerKmEnduranceDriver;
}