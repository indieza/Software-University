namespace SpaceStation.Models.Astronauts.Models
{
    public class Meteorologist : Astronaut
    {
        private const int InitialOxygen = 90;

        public Meteorologist(string name)
            : base(name, InitialOxygen)
        {
        }
    }
}