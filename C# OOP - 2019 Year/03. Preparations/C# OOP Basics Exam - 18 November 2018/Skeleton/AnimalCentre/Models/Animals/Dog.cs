
namespace AnimalCentre.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;


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