namespace SpaceStation.Models.Mission
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;
    using System.Collections.Generic;
    using System.Linq;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                IAstronaut astronaut = astronauts.FirstOrDefault(a => a.CanBreath);

                if (astronaut == null)
                {
                    break;
                }

                while (planet.Items.Count != 0)
                {
                    string item = planet.Items.FirstOrDefault();
                    astronaut.Breath();

                    astronaut.Bag.AddItem(item);
                    planet.RemoveItem(item);

                    if (astronaut.CanBreath == false)
                    {
                        break;
                    }
                }

                if (planet.Items.Count == 0)
                {
                    break;
                }
            }
        }
    }
}