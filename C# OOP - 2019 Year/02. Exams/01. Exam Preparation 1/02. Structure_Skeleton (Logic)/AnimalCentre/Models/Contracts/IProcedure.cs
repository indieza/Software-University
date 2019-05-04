using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        ICollection<IAnimal> ProcedureHistory { get; }

        string History();

        void DoService(IAnimal animal, int procedureTime);
    }
}