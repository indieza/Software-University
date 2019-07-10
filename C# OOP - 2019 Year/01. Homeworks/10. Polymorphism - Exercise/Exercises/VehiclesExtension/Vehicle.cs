namespace Vehicles
{
    using System;

    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;

            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            protected set => this.fuelConsumption = value;
        }

        public double TankCapacity
        {
            get => this.tankCapacity;
            protected set => this.tankCapacity = value;
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

        public virtual void Refuel(double fuel)
        {
            double newFuel = this.FuelQuantity + fuel;

            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (newFuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}