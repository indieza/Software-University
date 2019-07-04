namespace NeedForSpeed.Motorcycles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}