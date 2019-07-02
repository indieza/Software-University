namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly IList<Car> cars;

        public Engine()
        {
            this.cars = new List<Car>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                Car car = CreateCar();
                cars.Add(car);
            }

            string command = Console.ReadLine();
            CheckCommand(command);
        }

        private void CheckCommand(string command)
        {
            if (command == "fragile")
            {
                List<string> fragile = this.cars
                    .Where(x => x.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = this.cars
                    .Where(x => x.CargoType == "flamable" && x.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static Car CreateCar()
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

            Tire tire1 = new Tire(tire1Pressure, tire1age);
            Tire tire2 = new Tire(tire2Pressure, tire2age);
            Tire tire3 = new Tire(tire3Pressure, tire3age);
            Tire tire4 = new Tire(tire4Pressure, tire4age);

            Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1, tire2, tire3, tire4);

            return car;
        }
    }
}