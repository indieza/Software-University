namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Constraints;
    using AnimalCentre.Models.Contracts;
    using System;

    public class Chip : Procedure
    {
        private readonly int RemoveHappiness = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);

            if (animal.IsChipped == true)
            {
                throw new ArgumentException(string.Format(ExceptionsMessages.AnimalIsChipped, animal.Name));
            }

            animal.Happiness -= RemoveHappiness;
            animal.IsChipped = true;
            base.procedureHistory.Add(animal);
        }
    }
}