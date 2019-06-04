namespace _11.PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string name, string element, double health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name { get; set; }

        public string Element { get; set; }

        public double Health { get; set; }
    }
}
