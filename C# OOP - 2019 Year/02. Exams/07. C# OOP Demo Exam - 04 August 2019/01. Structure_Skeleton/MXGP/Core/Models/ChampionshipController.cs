namespace MXGP.Core.Models
{
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Motorcycles.Models;
    using MXGP.Models.Races;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories.Models;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        private const int MinRidersCount = 3;
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
            if (this.riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            if (this.motorcycleRepository.GetByName(motorcycleModel) == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            IRider rider = this.riderRepository.GetByName(riderName);
            IMotorcycle motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            rider.AddMotorcycle(motorcycle);
            return string.Format(OutputMessages.MotorcycleAdded, rider.Name, motorcycle.Model);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (this.raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (this.riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            IRace race = this.raceRepository.GetByName(raceName);
            IRider rider = this.riderRepository.GetByName(riderName);

            race.AddRider(rider);
            return string.Format(OutputMessages.RiderAdded, rider.Name, race.Name);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException(ExceptionMessages.MotorcycleExists, model);
            }

            IMotorcycle motorcycle = null;

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
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);
            return string.Format(OutputMessages.RaceCreated, race.Name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            IRider rider = new Rider(riderName);
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

            List<IRider> riders = race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .ToList();

            if (riders.Count < MinRidersCount)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MinRidersCount));
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, riders[0].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, riders[1].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, riders[2].Name, race.Name));

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}