using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem
{
    public class Car
    {
        private string make;
        private string registrationNumber;

        public Car(string make, string registrationNumber)
        {
            this.Make = make;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make
        {
            get => this.make;
            private set => this.make = value;
        }

        public string RegistrationNumber
        {
            get => this.registrationNumber;
            private set => this.registrationNumber = value;
        }
    }
}
