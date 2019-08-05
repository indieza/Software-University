namespace MXGP.Models.Races.Models
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Race : IRace
    {
        private const int MinModelLength = 5;
        private const int MinLapsCount = 1;
        private string name;
        private int laps;
        private readonly List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinModelLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinModelLength));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;

            private set
            {
                if (value < MinLapsCount)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MinLapsCount));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentException(ExceptionMessages.NullRider);
            }

            if (rider.Motorcycle == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }

            if (this.riders.Any(r => r.Name == rider.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
            }

            this.riders.Add(rider);
        }
    }
}