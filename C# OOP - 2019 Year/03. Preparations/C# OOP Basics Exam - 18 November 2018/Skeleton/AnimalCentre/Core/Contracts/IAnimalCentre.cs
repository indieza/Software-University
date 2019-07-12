namespace AnimalCentre.Core.Contracts
{
    public interface IAnimalCentre
    {
        string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime);

        string Chip(string name, int procedureTime);

        string Vaccinate(string name, int procedureTime);

        string Fitness(string name, int procedureTime);

        string Play(string name, int procedureTime);

        string DentalCare(string name, int procedureTime);

        string NailTrim(string name, int procedureTime);

        string Adopt(string animalName, string owner);

        string History(string type);
    }
}