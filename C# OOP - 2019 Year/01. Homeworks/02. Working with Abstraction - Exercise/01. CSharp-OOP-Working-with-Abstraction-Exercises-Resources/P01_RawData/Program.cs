using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3age, double tire4Pressure, int tire4age)
        {
            this.model = model;
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
            this.tires = new KeyValuePair<double, int>[] { KeyValuePair.Create(tire1Pressure, tire1Age), KeyValuePair.Create(tire2Pressure, tire2Age), KeyValuePair.Create(tire3Pressure, tire3age), KeyValuePair.Create(tire4Pressure, tire4age) };
        }
        public string model;
        public int engineSpeed;
        public int enginePower;
        public int cargoWeight;
        public string cargoType;
        public KeyValuePair<double, int>[] tires;
    }
    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                double tire1Pressure = double.Parse(parameters[5]);
                int tire1age = int.Parse(parameters[6]);
                double tire2Pressure = double.Parse(parameters[7]);
                int tire2age = int.Parse(parameters[8]);
                double tire3Pressure = double.Parse(parameters[9]);
                int tire3age = int.Parse(parameters[10]);
                double tire4Pressure = double.Parse(parameters[11]);
                int tire4age = int.Parse(parameters[12]);
                cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1age, tire2Pressure, tire2age, tire3Pressure, tire3age, tire4Pressure, tire4age));
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.cargoType == "fragile" && x.tires.Any(y => y.Key < 1))
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.cargoType == "flamable" && x.enginePower > 250)
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
