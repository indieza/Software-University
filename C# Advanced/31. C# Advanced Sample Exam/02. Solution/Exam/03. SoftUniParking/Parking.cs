using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        private int count;

        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.Cars = new List<Car>();
            this.Count = this.Cars.Count;
        }

        public List<Car> Cars
        {
            get
            {
                return this.cars;
            }
            private set
            {
                this.cars = value;
            }
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

        public int Count
        {
            get
            {
                return this.Cars.Count;
            }
            private set
            {
                this.count = this.Cars.Count;
            }
        }

        public string AddCar(Car car)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.Count >= this.Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                this.Cars.Add(new Car(car.Make, car.Model, car.HorsePower, car.RegistrationNumber));
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string GetCar(string registrationNumber)
        {
            if (!this.Cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                return this.Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber).ToString();
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            bool isRemoved = false;

            foreach (var car in this.Cars)
            {
                if (car.RegistrationNumber == registrationNumber)
                {
                    isRemoved = true;
                    this.Cars.Remove(this.Cars.First(c => c.RegistrationNumber == registrationNumber));
                    break;
                }
            }

            return isRemoved == true
                ? $"Successfully removed {registrationNumber}"
                : "Car with that registration number, doesn't exist!";
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                Console.WriteLine(RemoveCar(number));
            }
        }
    }
}