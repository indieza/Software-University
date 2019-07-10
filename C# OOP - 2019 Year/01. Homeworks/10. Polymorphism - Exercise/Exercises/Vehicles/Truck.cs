namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirCondition = 1.6;
        private const double InnitialFuelAmount = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += AirCondition;
        }

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel * InnitialFuelAmount;
        }
    }
}