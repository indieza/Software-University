namespace AnimalCentre.Models.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int energy, int happiness, int produceTime)
            : base(name, energy, happiness, produceTime)
        {
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Cat), this.Name, this.Happiness, this.Energy);
        }
    }
}