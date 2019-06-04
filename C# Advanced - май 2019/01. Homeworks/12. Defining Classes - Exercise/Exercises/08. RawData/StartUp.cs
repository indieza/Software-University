namespace _08.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                Queue<string> input = new Queue<string>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries));
                string model = input.Dequeue();
                int engineSpeed = int.Parse(input.Dequeue());
                int enginePower = int.Parse(input.Dequeue());
                int cargoWeight = int.Parse(input.Dequeue());
                string cargoType = input.Dequeue();

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                List<Tire> tires = new List<Tire>();

                while (input.Any())
                {
                    double tirePressure = double.Parse(input.Dequeue());
                    int tireYear = int.Parse(input.Dequeue());
                    Tire tire = new Tire(tirePressure, tireYear);
                    tires.Add(tire);
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.CargoType == command &&
                x.Tire.Any(y => y.Pressure < 1)))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else
            {
                foreach (var car in cars.Where(x => x.Cargo.CargoType == command && x.Engine.EnginePower > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }
}