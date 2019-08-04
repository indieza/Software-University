namespace MXGP.Models.Motorcycles.Models
{
    using MXGP.Utilities.Messages;
    using System;

    public class SpeedMotorcycle : Motorcycle
    {
        private const double InitialCubicCentimeters = 125.0;
        private const int MaxHP = 69;
        private const int MinHP = 50;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, InitialCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => base.HorsePower;

            protected set
            {
                if (value < MinHP || value > MaxHP)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                base.HorsePower = value;
            }
        }
    }
}