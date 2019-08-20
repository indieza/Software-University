namespace SpaceStation.Models.Mission
{
    using Astronauts.Contracts;
    using Planets;
    using System.Collections.Generic;

    public interface IMission
    {
        void Explore(IPlanet planet, ICollection<IAstronaut> astronauts);
    }
}