using System;
using System.Collections.Generic;
using System.Linq;

internal class CarSalesman
{
    private static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var engines = new List<Engine>();
        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = tokens[0];
            var power = int.Parse(tokens[1]);

            if (tokens.Length == 2)
            {
                engines.Add(new Engine(model, power));
            }
            else if (tokens.Length == 3)
            {
                if (int.TryParse(tokens[2], out int displacement))
                {
                    engines.Add(new Engine(model, power, displacement));
                }
                else
                {
                    engines.Add(new Engine(model, power, tokens[2]));
                }
            }
            else if (tokens.Length == 4)
            {
                engines.Add(new Engine(model, power, int.Parse(tokens[2]), tokens[3]));
            }
        }

        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = tokens[0];
            var engine = engines.First(e => e.Model == tokens[1]);

            if (tokens.Length == 2)
            {
                cars.Add(new Car(model, engine));
            }
            else if (tokens.Length == 3)
            {
                if (int.TryParse(tokens[2], out int weight))
                {
                    cars.Add(new Car(model, engine, weight));
                }
                else
                {
                    cars.Add(new Car(model, engine, tokens[2]));
                }
            }
            else if (tokens.Length == 4)
            {
                cars.Add(new Car(model, engine, int.Parse(tokens[2]), tokens[3]));
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}