namespace SpaceStation.Models.Astronauts.Models
{
    public class Biologist : Astronaut
    {
        private const int InitialOxygen = 70;

        public Biologist(string name)
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - 5 < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= 5;
            }
        }
    }
}