using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Data.Procedure
{
    public class DentalCare : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness += 12;
            animal.Energy += 10;
        }
    }
}