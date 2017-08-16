public class Pokemon
{
    private string pokemonName;
    private string pokemonType;

    public Pokemon(string pokemonName, string pokemonType)
    {
        this.pokemonName = pokemonName;
        this.pokemonType = pokemonType;
    }

    public string PokemonName
    {
        get { return this.pokemonName; }
        set { this.pokemonName = value; }
    }

    public string PokemonType
    {
        get { return this.pokemonType; }
        set { this.pokemonType = value; }
    }

    public override string ToString()
    {
        return $"{this.pokemonName} {this.pokemonType}";
    }
}