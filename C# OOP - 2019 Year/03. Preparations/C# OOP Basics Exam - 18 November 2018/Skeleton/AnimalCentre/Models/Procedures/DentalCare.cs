namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class DentalCare : Procedure
    {
        private readonly int AddHappiness = 12;
        private readonly int AddEnergy = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);
            animal.Happiness += AddHappiness;
            animal.Energy += AddEnergy;
            base.procedureHistory.Add(animal);
        }
    }
}