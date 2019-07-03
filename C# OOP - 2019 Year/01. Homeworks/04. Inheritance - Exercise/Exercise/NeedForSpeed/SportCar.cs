
namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class SportCar : Car
    {
        private const double defaultFuelConsumption = 10;

        public SportCar(double fuel, int horsePower) 
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