namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirCondition = 1.6;
        private const double InitialFuelAmount = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirCondition;
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
            this.FuelQuantity -= fuel * InitialFuelAmount;
        }
    }
}