namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Restaurant
    {
        private readonly IList<Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        public string Name { get; private set; }

        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }

        public bool Buy(string name)
        {
            if (this.data.FirstOrDefault(s => s.Name == name) == null)
            {
                return false;
            }
            else
            {
                this.data.Remove(this.data.FirstOrDefault(s => s.Name == name));
                return true;
            }
        }

        public Salad GetHealthiestSalad()
        {
            int min = this.data.Min(s => s.GetTotalCalories());

            return this.data.FirstOrDefault(s => s.GetTotalCalories() == min);
        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}