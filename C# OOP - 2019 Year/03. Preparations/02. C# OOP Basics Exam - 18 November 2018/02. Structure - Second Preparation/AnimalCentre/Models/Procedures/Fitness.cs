namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class Fitness : Procedure
    {
        private const int InitialHappiness = 3;
        private const int InitialEnergy = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);
            animal.Happiness -= InitialHappiness;
            animal.Energy += InitialEnergy;
            animal.ProcedureTime -= procedureTime;
        }
    }
}