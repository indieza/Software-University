namespace NeedForSpeed.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SportCar : Car
    {
        private const double defaultFuelConsumption = 10;

        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            set => base.FuelConsumption = defaultFuelConsumption;
        }
    }
}