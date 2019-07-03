
namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Car : Vehicle
    {
        private const double defaultFuelConsumption = 3;

        public Car(double fuel, int horsePower)
            : base(fuel, horsePower)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            set => base.FuelConsumption = defaultFuelConsumption;
        }
    }
}