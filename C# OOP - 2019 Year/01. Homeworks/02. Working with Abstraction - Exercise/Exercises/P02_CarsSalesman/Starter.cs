namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Starter
    {
        private readonly List<Car> cars;
        private readonly List<Engine> engines;

        public Starter()
        {
            this.cars = new List<Car>();
            this.engines = new List<Engine>();
        }

        public void Run()
        {
            int engineCount = int.Parse(Console.ReadLine());
            AddEngines(engineCount);

            int carCount = int.Parse(Console.ReadLine());
            AddCars(carCount);

            PrintData();
        }

        private void PrintData()
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private void AddCars(int carCount)
        {
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                string engineModel = parameters[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

                int weight = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
                {
                    cars.Add(new Car(model, engine, weight));
                }
                else if (parameters.Length == 3)
                {
                    string color = parameters[2];
                    cars.Add(new Car(model, engine, color));
                }
                else if (parameters.Length == 4)
                {
                    string color = parameters[3];
                    cars.Add(new Car(model, engine, int.Parse(parameters[2]), color));
                }
                else
                {
                    cars.Add(new Car(model, engine));
                }
            }
        }

        private void AddEngines(int engineCount)
        {
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                int power = int.Parse(parameters[1]);

                if (parameters.Length == 3)
                {
                    bool isDeplacement = int.TryParse(parameters[2], out int displacement);

                    if (isDeplacement)
                    {
                        Engine engine = new Engine(model, power, displacement);
                        engines.Add(engine);
                    }
                    else
                    {
                        string efficiency = parameters[2];
                        Engine engine = new Engine(model, power, efficiency);
                        engines.Add(engine);
                    }
                }
                else if (parameters.Length == 4)
                {
                    string efficiency = parameters[3];
                    engines.Add(new Engine(model, power, int.Parse(parameters[2]), efficiency));
                }
                else
                {
                    engines.Add(new Engine(model, power));
                }
            }
        }
    }
}