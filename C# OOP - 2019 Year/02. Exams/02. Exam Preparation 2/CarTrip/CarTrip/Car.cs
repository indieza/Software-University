using System;

namespace CarTrip
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKm;

        public Car(string model, double tankCapacity, double tank, double fuelConsumptionPerKm)
        {
            this.Model = model;
            this.TankCapacity = tankCapacity;
            this.FuelAmount = tank;
            this.fuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double TankCapacity { get; private set; }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Model)} is required");
                }

                this.model = value;
            }
        }

        public double FuelAmount
        {
            get => this.fuelAmount;
            set
            {
                if (value > this.TankCapacity)
                {
                    throw new ArgumentException($"{nameof(FuelAmount)} cannot be more than {nameof(this.TankCapacity)}");
                }

                this.fuelAmount = value;
            }
        }

        public double FuelConsumptionPerKm
        {
            get => this.fuelConsumptionPerKm;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Invalid {nameof(this.FuelConsumptionPerKm)}");
                }

                this.fuelConsumptionPerKm = value;
            }
        }

        public string Drive(double distance)
        {
            double tripConsumotion = distance * this.FuelConsumptionPerKm;

            if (this.FuelAmount < tripConsumotion)
            {
                throw new InvalidOperationException("Cannot travel this distance");
            }

            this.FuelAmount -= tripConsumotion;
            return "Have a nice trip";
        }

        public void Refuel(double fuelAmount)
        {
            double totalFuelAmount = this.FuelAmount + fuelAmount;

            if (totalFuelAmount > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fill {fuelAmount} in the tank");
            }

            this.FuelAmount = totalFuelAmount;
        }
    }
}
