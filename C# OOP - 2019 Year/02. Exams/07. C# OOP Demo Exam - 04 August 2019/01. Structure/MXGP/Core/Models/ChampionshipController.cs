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
            throw new NotImplementedException();
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            throw new NotImplementedException();
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            throw new NotImplementedException();
        }

        public string CreateRace(string name, int laps)
        {
            throw new NotImplementedException();
        }

        public string CreateRider(string riderName)
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}