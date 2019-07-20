namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class Play : Procedure
    {
        private const int InitialEnergy = 6;
        private const int InitialHappiness = 12;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);
            animal.Energy -= InitialEnergy;
            animal.Happiness += InitialHappiness;
            animal.ProcedureTime -= procedureTime;
        }
    }
}