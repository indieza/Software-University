namespace AnimalCentre.Models
{
    using AnimalCentre.Constraints;
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class Hotel : IHotel
    {
        private readonly Dictionary<string, IAnimal> animals;
        private int capacity;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
            this.capacity = 10;
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;

        public void Accommodate(IAnimal animal)
        {
            if (capacity <= 0)
            {
                throw new InvalidOperationException(ExceptionsMessages.NotEnoughtSpaceInTheHotel);
            }
            else if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException(string.Format(ExceptionsMessages.AnimalAlreadyExist, animal.Name));
            }
            else
            {
                this.animals.Add(animal.Name, animal);
                this.capacity--;
            }
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException(string.Format(ExceptionsMessages.AnimalDoesNotExist, animalName));
            }

            this.animals[animalName].Owner = owner;
            this.animals[animalName].IsAdopt = true;
            this.animals.Remove(animalName);
            this.capacity++;
        }
    }
}