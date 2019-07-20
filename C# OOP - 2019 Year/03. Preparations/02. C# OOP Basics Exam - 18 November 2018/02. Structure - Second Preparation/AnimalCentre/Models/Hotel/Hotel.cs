namespace AnimalCentre.Models.Hotel
{
    using AnimalCentre.Contracts;
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;

    public class Hotel : IHotel
    {
        private readonly Dictionary<string, IAnimal> animals;
        private int capacity;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
            this.capacity = 10;
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals.ToImmutableDictionary();

        public void Accommodate(IAnimal animal)
        {
            if (this.capacity == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughtCapacity);
            }

            if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AnimalAlreadyExist, animal.Name));
            }

            this.animals.Add(animal.Name, animal);
            capacity--;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AnimalDoesNotExist, animalName));
            }

            this.animals[animalName].IsAdopt = true;
            this.animals[animalName].Owner = owner;
            this.animals.Remove(animalName);
            this.capacity++;
        }
    }
}