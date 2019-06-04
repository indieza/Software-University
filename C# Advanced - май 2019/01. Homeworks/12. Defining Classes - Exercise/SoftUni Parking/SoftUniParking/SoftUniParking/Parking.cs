using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count => this.cars.Count();

        public string AddCar(Car carToAdd)
        {
            if (this.cars.Any(c => c.RegistrationNumber == carToAdd.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.capacity <= cars.Count)
            {
                return "Parking is full!";
            }
            else
            {
                this.cars.Add(carToAdd);
                return $"Successfully added new car {carToAdd.Make} {carToAdd.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!this.cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                this.cars.Remove(this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var currentNumber in registrationNumbers)
            {
                this.cars.RemoveAll(c => c.RegistrationNumber == currentNumber);
            }
        }
    }
}