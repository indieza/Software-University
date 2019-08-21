namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Astronauts.Models;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories.Models;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly AstronautRepository astronautRepository;
        private readonly PlanetRepository planetRepository;
        private readonly IMission mission;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
            this.exploredPlanetsCount = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;

                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;

                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronautRepository.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded,
                astronaut.GetType().Name,
                astronaut.Name);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            planet.AddItems(items);

            this.planetRepository.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planet.Name);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astronauts = this.astronautRepository
                .Models
                .Where(a => a.Oxygen > 60)
                .ToList();

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = this.planetRepository.FindByName(planetName);
            this.mission.Explore(planet, astronauts);
            this.exploredPlanetsCount++;

            return string.Format(OutputMessages.PlanetExplored,
                planet.Name,
                astronauts.Where(a => a.CanBreath == false).Count());
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (IAstronaut astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine($"Name: { astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {(astronaut.Bag.Items.Count == 0 ? "none" : string.Join(", ", astronaut.Bag.Items))} ");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (this.astronautRepository.FindByName(astronautName) == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            IAstronaut astronaut = this.astronautRepository.FindByName(astronautName);
            this.astronautRepository.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}