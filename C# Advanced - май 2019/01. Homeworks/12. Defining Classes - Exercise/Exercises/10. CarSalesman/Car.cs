namespace _10.CarSalesman
{
    using System;

    public class Car
    {
        public Car(string model, Engine engine, string weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public void PrintCar()
        {
            Console.WriteLine($"{this.Model}:");
            Console.WriteLine($"  {this.Engine.Model}:");
            Console.WriteLine($"    Power: {this.Engine.Power}");
            Console.WriteLine($"    Displacement: {this.Engine.Displacement}");
            Console.WriteLine($"    Efficiency: {this.Engine.Efficiency}");
            Console.WriteLine($"  Weight: {this.Weight}");
            Console.WriteLine($"  Color: {this.Color}");
        }

    }
}
