namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AirCondition = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirCondition;
        }
    }
}