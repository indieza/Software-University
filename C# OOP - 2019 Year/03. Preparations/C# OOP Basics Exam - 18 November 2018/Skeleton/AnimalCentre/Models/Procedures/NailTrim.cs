
namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AnimalCentre.Models.Contracts;

    public class NailTrim : Procedure
    {

        private readonly int RemoveHappiness = 7;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);
            animal.Happiness -= RemoveHappiness;
            base.procedureHistory.Add(animal);
        }
    }
}