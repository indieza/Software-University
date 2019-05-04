using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace AnimalCentre.Data.Hotel
{
    public class Hotel : IHotel
    {
        private const int Capacity = 10;
        private readonly Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals.ToImmutableDictionary();

        public void Accommodate(IAnimal animal)
        {
            throw new NotImplementedException();
        }

        public void Adopt(string animalName, string owner)
        {
            throw new NotImplementedException();
        }
    }
}