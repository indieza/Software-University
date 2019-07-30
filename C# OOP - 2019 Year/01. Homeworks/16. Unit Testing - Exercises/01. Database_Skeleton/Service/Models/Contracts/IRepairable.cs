using System.Collections.Generic;

namespace Service.Models.Contracts
{
    public interface IRepairable
    {
        string Make { get; }

        IReadOnlyCollection<IPart> Parts { get; }

        void AddPart(IPart part);

        void RemovePart(string partName);

        void RepairPart(string partName);
    }
}
