namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vehicle
    {
        private double defaultFuelConsumption;
        private double fuelConsumption;
        private double fuel;
        private int horsePower;

        protected Vehicle(int horsePower, double fuel)
        {
            this.FuelConsumption = 1.25;
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }

        public double DefaultFuelConsumption
        {
            get => this.defaultFuelConsumption;
            set => this.defaultFuelConsumption = value;
        }

        public virtual double FuelConsumption
        {
            get => this.fuelConsumption;
            set => this.fuelConsumption = value;
        }

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
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}