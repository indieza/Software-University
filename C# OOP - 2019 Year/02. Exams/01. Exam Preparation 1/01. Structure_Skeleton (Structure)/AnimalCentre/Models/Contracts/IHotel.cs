namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;

    public interface IHotel
    {
        int Capacity { get; }

        IDictionary<string, IAnimal> Animals { get; }

        void Accommodate(IAnimal animal);

        void Adopt(string animalName, string owner);
    }
}