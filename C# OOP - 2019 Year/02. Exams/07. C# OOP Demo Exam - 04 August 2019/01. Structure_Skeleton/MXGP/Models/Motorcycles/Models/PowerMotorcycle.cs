namespace MXGP.Models.Motorcycles.Models
{
    using MXGP.Utilities.Messages;
    using System;

    public class PowerMotorcycle : Motorcycle
    {
        private const double InitialCubicCentimeters = 450.0;
        private const int MaxHP = 100;
        private const int MinHP = 70;

        public PowerMotorcycle(string model, int horsePower)
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