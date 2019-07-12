namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class Fitness : Procedure
    {
        private readonly int RemoveHappiness = 3;
        private readonly int AddEnergy = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);
            animal.Happiness -= RemoveHappiness;
            animal.Energy += AddEnergy;
            base.procedureHistory.Add(animal);
        }
    }
}