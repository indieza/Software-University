namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Contracts;
    using AnimalCentre.Models.Contracts;
    using System;

    public class Chip : Procedure
    {
        private const int InitialHappiness = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);

            animal.Happiness -= InitialHappiness;

            if (animal.IsChipped == true)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AnimalIsAlreadyChipped, animal.Name));
            }

            animal.IsChipped = true;
            animal.ProcedureTime -= procedureTime;
        }
    }
}