public class AggressiveDriver : Driver
{
    private const double FuelConsumptionPerKmAggressiveDriver = 2.7;
    private const double SpeedMultiply = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car)
    {
    }

    public override double FuelConsumptionPerKm => FuelConsumptionPerKmAggressiveDriver;

    public override double Speed => base.Speed * SpeedMultiply;
}