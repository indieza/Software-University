namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        string History();

        void DoService(IAnimal animal, int procedureTime);
    }
}