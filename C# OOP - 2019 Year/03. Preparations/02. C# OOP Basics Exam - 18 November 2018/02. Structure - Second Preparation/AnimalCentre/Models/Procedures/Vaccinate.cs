namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;

    public class Vaccinate : Procedure
    {
        private const int InitialEnergy = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(animal, procedureTime);
            animal.Energy -= InitialEnergy;
            animal.IsVaccinated = true;
            animal.ProcedureTime -= procedureTime;
        }
    }
}