namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class NailTrim : Procedure
    {
        private const int InitialHappiness = 7;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);
            animal.Happiness -= InitialHappiness;
            animal.ProcedureTime -= procedureTime;
        }
    }
}