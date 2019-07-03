
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
        protected Vehicle(double fuel, int horsePower)
        {
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
            set => this.fuelConsumption = 1.25;
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
            this.Fuel -= this.FuelConsumption * kilometers/100;
        }
    }
}