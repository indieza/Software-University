namespace _10.CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int engineCount = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engineCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string engineModel = input[0];
                int enginePower = int.Parse(input[1]);

                string displacement = input.Length > 2 ? !char.IsLetter(input[2][0]) ? input[2] : "n/a" : "n/a";
                displacement = input.Length > 3 ? !char.IsLetter(input[3][0]) ? input[3] : displacement : displacement;

                string efficiency = input.Length > 2 ? char.IsLetter(input[2][0]) ? input[2] : "n/a" : "n/a";
                efficiency = input.Length > 3 ? char.IsLetter(input[3][0]) ? input[3] : efficiency : efficiency;

                Engine engine = new Engine(engineModel, enginePower, displacement, efficiency);
                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = input[0];
                string engineModel = input[1];
                string weight = input.Length > 2 ? !char.IsLetter(input[2][0]) ? input[2] : "n/a" : "n/a";
                weight = input.Length > 3 ? !char.IsLetter(input[3][0]) ? input[3] : weight : weight;

                string color = input.Length > 2 ? char.IsLetter(input[2][0]) ? input[2] : "n/a" : "n/a";
                color = input.Length > 3 ? char.IsLetter(input[3][0]) ? input[3] : color : color;

                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);
                Car car = new Car(carModel, engine, weight, color);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                car.PrintCar();
            }
        }
    }
}