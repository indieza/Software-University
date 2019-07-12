
namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AnimalCentre.Models.Contracts;

    public class Play : Procedure
    {

        private readonly int AddHappiness = 12;
        private readonly int RemoveEnergy = 6;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);
            animal.Happiness += AddHappiness;
            animal.Energy -= RemoveEnergy;
            base.procedureHistory.Add(animal);
        }
    }
}