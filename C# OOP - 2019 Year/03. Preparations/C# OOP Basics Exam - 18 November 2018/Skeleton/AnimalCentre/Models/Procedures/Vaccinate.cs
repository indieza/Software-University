
namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AnimalCentre.Models.Contracts;

    public class Vaccinate : Procedure
    {

        private readonly int RemoveEnergy = 8;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);
            animal.Energy -= RemoveEnergy;
            animal.IsVaccinated = true;
            base.procedureHistory.Add(animal);
        }
    }
}