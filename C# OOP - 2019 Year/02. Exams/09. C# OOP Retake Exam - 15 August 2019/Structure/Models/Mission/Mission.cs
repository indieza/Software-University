namespace SpaceStation.Models.Mission
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;
    using System;
    using System.Collections.Generic;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            throw new NotImplementedException();
        }
    }
}