using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Data.Procedure
{
    public class NailTrim : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness -= 7;
        }
    }
}