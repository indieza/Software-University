namespace TheRace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceEntry
    {
        private const string ExistingRider = "Rider {0} is already added.";
        private const string RiderInvalid = "Rider cannot be null.";
        private const string RiderAdded = "Rider {0} added in race.";
        private const int MinParticipants = 2;
        private const string RaceInvalid = "The race cannot start with less than {0} participants.";

        private Dictionary<string, UnitRider> riders;

        public RaceEntry()
        {
            this.riders = new Dictionary<string, UnitRider>();
        }

        public int Counter
            => this.riders.Count;

        public string AddRider(UnitRider rider)
        {
            if (rider == null)
            {
                throw new InvalidOperationException(RiderInvalid);
            }

            if (this.riders.ContainsKey(rider.Name))
            {
                throw new InvalidOperationException(string.Format(ExistingRider, rider.Name));
            }

            this.riders.Add(rider.Name, rider);

            string result = string.Format(RiderAdded, rider.Name);

            return result;
        }

        public double CalculateAverageHorsePower()
        {
            if (this.riders.Count < MinParticipants)
            {
                throw new InvalidOperationException(string.Format(RaceInvalid, MinParticipants));
            }

            double averageHorsePower = this.riders
                .Values
                .Select(x => x.Motorcycle.HorsePower)
                .Average();

            return averageHorsePower;
        }
    }
}