namespace HealthyHeaven
{
    using System.Text;

    public class Vegetable
    {
        public Vegetable(string name, int calories)
        {
            this.Name = name;
            this.Calories = calories;
        }

        public string Name { get; private set; }

        public int Calories { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" - {this.Name} have {this.Calories} calories");
            return sb.ToString().TrimEnd();
        }
    }
}