namespace MXGP.Core.Models
{
    using MXGP.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MXGP.Repositories.Models;
    using MXGP.Utilities.Messages;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Models.Riders;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Motorcycles.Models;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Races.Models;
    using System.Linq;

    public class ChampionshipController : IChampionshipController
    {
        private const int MinParticipantsCount = 3;
        private readonly MotorcycleRepository motorcycleRepository;
        private readonly RaceRepository raceRepository;
        private readonly RiderRepository riderRepository;

        public ChampionshipController()
        {
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
            this.riderRepository = new RiderRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = this.riderRepository.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            IMotorcycle motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, rider.Name, motorcycle.Model);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRider rider = this.riderRepository.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, rider.Name, race.Name);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = this.motorcycleRepository.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, motorcycle.Model));
            }

            switch (type)
            {
                case "Speed":
                    motorcycle = new SpeedMotorcycle(model, horsePower);
                    break;

                case "Power":
                    motorcycle = new PowerMotorcycle(model, horsePower);
                    break;

                default:
                    break;
            }

            this.motorcycleRepository.Add(motorcycle);

            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, motorcycle.Model);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, race.Name));
            }

            race = new Race(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, race.Name);
        }

        public string CreateRider(string riderName)
        {
            IRider rider = this.riderRepository.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, rider.Name));
            }

            rider = new Rider(riderName);
            this.riderRepository.Add(rider);

            return string.Format(OutputMessages.RiderCreated, rider.Name);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            List<IRider> participants = race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .ToList();

            if (participants.Count < MinParticipantsCount)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, race.Name, MinParticipantsCount));
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, participants[0].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, participants[1].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, participants[2].Name, race.Name));

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}