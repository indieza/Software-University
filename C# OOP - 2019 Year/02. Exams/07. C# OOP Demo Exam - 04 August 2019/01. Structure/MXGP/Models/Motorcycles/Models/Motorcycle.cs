namespace MXGP.Models.Motorcycles.Models
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities.Messages;
    using System;

    public abstract class Motorcycle : IMotorcycle
    {
        private const int MinModelLength = 4;
        private string model;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinModelLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MinModelLength));
                }

                this.model = value;
            }
        }

        public virtual int HorsePower { get; protected set; }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}