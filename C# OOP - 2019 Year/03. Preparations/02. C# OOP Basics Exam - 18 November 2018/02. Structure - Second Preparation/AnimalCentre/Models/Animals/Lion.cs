namespace AnimalCentre.Models.Animals
{
    public class Lion : Animal
    {
        public Lion(string name, int energy, int happiness, int procedureTime)
            : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), this.GetType().Name, this.Name, this.Happiness, this.Energy);
        }
    }
}