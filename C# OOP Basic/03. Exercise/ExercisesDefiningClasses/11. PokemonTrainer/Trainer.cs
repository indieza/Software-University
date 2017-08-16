using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    private string name;
    private int numberOfBadges;
    private List<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.name = name;
        this.numberOfBadges = 0;
        this.pokemons = new List<Pokemon>();
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int NumberOfBadges
    {
        get { return this.numberOfBadges; }
        set { this.numberOfBadges = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public void AddBadge(string element)
    {
        int badges = this.pokemons.Count(pokemon => pokemon.Element == element);

        if (badges > 0)
        {
            this.numberOfBadges++;
        }
        else
        {
            this.pokemons.ForEach(pokemon => pokemon.Health -= 10);
            this.pokemons = this.pokemons.Where(pokemon => pokemon.Health > 0).ToList();
        }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.numberOfBadges} {this.pokemons.Count}";
    }
}