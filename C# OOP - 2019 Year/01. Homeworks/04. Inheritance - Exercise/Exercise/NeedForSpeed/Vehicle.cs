namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        private double fuelConsumption;
        private double fuel;
        private int horsePower;

        protected Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public double Fuel
        {
            get => this.fuel;
            set => this.fuel = value;
        }

        public int HorsePower
        {
            get => this.horsePower;
            set => this.horsePower = value;
        }

        public virtual void Drive(double kilometers)
        {
            double leftFuel = this.Fuel - this.FuelConsumption * kilometers;

            if (leftFuel >= 0)
            {
                this.Fuel -= this.FuelConsumption * kilometers;
            }
        }
    }
}