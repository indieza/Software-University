namespace P02_CarsSalesman
{
    using System.Text;

    public class Engine
    {
        private const string offset = "  ";

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Model = model;
            this.Power = power;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{offset}{this.Model}:");
            sb.AppendLine($"{offset}{offset}Power: {this.Power}");
            sb.AppendLine(
                $"{offset}{offset}Displacement: {(this.Displacement == -1 ? "n/a" : this.Displacement.ToString())}");
            sb.AppendLine($"{offset}{offset}Efficiency: { this.Efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}