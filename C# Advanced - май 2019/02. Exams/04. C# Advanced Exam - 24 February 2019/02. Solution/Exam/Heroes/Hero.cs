namespace Heroes
{
    using System.Text;

    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public Item Item { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hero: {this.Name} – {this.Level}lvl");
            sb.AppendLine($"Item:");
            sb.AppendLine($"  * Strength: {this.Item.Strength}");
            sb.AppendLine($"  * Ability: {this.Item.Ability}");
            sb.AppendLine($"  * Intelligence: {this.Item.Intelligence}");

            return sb.ToString().TrimEnd();
        }
    }
}