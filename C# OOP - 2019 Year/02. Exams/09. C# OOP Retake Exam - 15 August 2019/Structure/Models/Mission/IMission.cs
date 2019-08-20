namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using Astronauts.Contracts;
    using Planets;

    public interface IMission
    {
        void Explore(IPlanet planet, ICollection<IAstronaut> astronauts);
    }
}
