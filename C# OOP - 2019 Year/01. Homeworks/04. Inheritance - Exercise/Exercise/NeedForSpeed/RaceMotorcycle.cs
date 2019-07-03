
namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class RaceMotorcycle : Motorcycle
    {
        private const double defaultFuelConsumption = 8;

        public RaceMotorcycle(double fuel, int horsePower)
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