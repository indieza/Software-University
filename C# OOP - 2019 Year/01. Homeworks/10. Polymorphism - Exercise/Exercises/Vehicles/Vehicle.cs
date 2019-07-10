namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set => this.fuelQuantity = value;
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            protected set => this.fuelConsumption = value;
        }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public abstract void Refuel(double fuel);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}