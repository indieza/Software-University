using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Data.Procedure
{
    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Energy -= 6;
            animal.Happiness += 12;
        }
    }
}