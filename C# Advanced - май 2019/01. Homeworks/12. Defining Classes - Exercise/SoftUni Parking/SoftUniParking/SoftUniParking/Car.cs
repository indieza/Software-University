using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int hoursePower;
        private string registrationNumber;

        public Car(string make, string model, int hoursePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = hoursePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.hoursePower;
            }
            private set
            {
                this.hoursePower = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                this.registrationNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"HorsePower: {this.HorsePower}");
            sb.AppendLine($"RegistrationNumber: {this.RegistrationNumber}");

            return sb.ToString().Trim();
        }
    }
}