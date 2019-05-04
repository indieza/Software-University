using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Data.Procedure
{
    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Energy -= 8;
            animal.IsVaccinated = true;
        }
    }
}