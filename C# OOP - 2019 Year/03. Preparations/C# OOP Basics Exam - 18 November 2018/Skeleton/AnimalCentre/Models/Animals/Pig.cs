namespace AnimalCentre.Models.Animals
{
    public class Pig : Animal
    {
        public Pig(string name, int energy, int happiness, int produceTime)
            : base(name, energy, happiness, produceTime)
        {
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Pig), this.Name, this.Happiness, this.Energy);
        }
    }
}