using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Data.Procedure
{
    public class Fitness : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness -= 3;
            animal.Energy += 10;
        }
    }
}