namespace _12.Google.Classes
{
    using System.Text;
    using System.Collections.Generic;

    public class People
    {
        public string Name { get; set; }

        public Company Company { get; set; }

        public Car Car { get; set; }

        public List<Parent> Parents { get; set; } = new List<Parent>();

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public List<Child> Children { get; set; } = new List<Child>();

        public override string ToString()
        {
            var peopleInfo = new StringBuilder();
            peopleInfo.AppendLine($"{this.Name}");
            peopleInfo.AppendLine($"Company:");
            if (this.Company != null)
            {
                peopleInfo.AppendLine($"{this.Company.CompanyName} {this.Company.Department} {this.Company.Salary:F2}");
            }

            peopleInfo.AppendLine($"Car:");
            if (this.Car != null)
            {
                peopleInfo.AppendLine($"{this.Car.CarModel} {this.Car.CarSpeed}");
            }
            peopleInfo.AppendLine($"Pokemon:");

            foreach (var pokemon in this.Pokemons)
            {
                peopleInfo.AppendLine($"{pokemon.PokemonName} {pokemon.PokemonType}");
            }

            peopleInfo.AppendLine($"Parents:");

            foreach (var parent in this.Parents)
            {
                peopleInfo.AppendLine($"{parent.ParentsName} {parent.ParentBirthday}");
            }

            peopleInfo.AppendLine($"Children:");

            foreach (var child in this.Children)
            {
                peopleInfo.AppendLine($"{child.ChildName} {child.ChildBirthday}");
            }

            return peopleInfo.ToString();
        }
    }
}
