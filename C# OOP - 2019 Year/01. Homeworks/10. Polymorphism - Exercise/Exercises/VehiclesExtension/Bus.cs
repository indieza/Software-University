namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AirCondition = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirCondition;
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= AirCondition;
            return base.Drive(distance);
        }
    }
}