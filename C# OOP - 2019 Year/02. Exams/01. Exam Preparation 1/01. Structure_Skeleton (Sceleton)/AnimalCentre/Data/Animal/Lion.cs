namespace AnimalCentre.Data.Animal
{
    public class Lion : Animal
    {
        public Lion(string name, int energy, int happiness, int procedureTime)
            : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            return $"    Animal type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}