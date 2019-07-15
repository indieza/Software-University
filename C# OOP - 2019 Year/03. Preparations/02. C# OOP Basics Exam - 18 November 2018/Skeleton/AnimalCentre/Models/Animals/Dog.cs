namespace AnimalCentre.Models.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int energy, int happiness, int produceTime)
            : base(name, energy, happiness, produceTime)
        {
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Dog), this.Name, this.Happiness, this.Energy);
        }
    }
}