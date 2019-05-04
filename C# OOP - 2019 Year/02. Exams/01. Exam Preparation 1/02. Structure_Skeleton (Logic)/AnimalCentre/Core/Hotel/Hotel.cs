using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core.Hotel
{
    public class Hotel : IHotel
    {
        private int capacity;
        private IDictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.Animals = new Dictionary<string, IAnimal>();
            this.Capacity = 10;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public IDictionary<string, IAnimal> Animals
        {
            get
            {
                return this.animals;
            }
            private set
            {
                this.animals = value;
            }
        }

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