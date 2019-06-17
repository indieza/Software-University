namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Restaurant
    {
        private readonly IDictionary<string, Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new Dictionary<string, Salad>();
        }

        public string Name { get; private set; }

        public void Add(Salad salad)
        {
            this.data.Add(salad.Name, salad);
        }

        public bool Buy(string name)
        {
            if (!this.data.ContainsKey(name))
            {
                return false;
            }
            else
            {
                this.data.Remove(name);
                return true;
            }
        }

        public Salad GetHealthiestSalad()
        {
            int min = this.data.Values.Min(s => s.GetTotalCalories());

            return this.data.Values.FirstOrDefault(s => s.GetTotalCalories() == min);
        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (var item in this.data.Values)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}