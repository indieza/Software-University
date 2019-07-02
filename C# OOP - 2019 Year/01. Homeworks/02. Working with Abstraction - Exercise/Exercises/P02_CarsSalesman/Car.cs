namespace P02_CarsSalesman
{
    using System.Text;

    public class Car
    {
        private const string offset = "  ";

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine(this.Engine.ToString());
            sb.AppendLine($"{offset}Weight: {(this.Weight == -1 ? "n/a" : this.Weight.ToString())}");
            sb.AppendLine($"{offset}Color: {this.Color}");

            return sb.ToString().TrimEnd();
        }
    }
}