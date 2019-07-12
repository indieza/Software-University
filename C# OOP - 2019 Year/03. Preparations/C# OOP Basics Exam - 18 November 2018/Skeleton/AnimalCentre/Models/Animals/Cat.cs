
namespace AnimalCentre.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Cat : Animal
    {
        public Cat(string name, int energy, int happiness, int produceTime) 
            : base(name, energy, happiness, produceTime)
        {
        }

        public override string ToString()
        {
            return string.Format( base.ToString(),nameof(Cat) ,this.Name,this.Happiness,this.Energy);
        }
    }
}