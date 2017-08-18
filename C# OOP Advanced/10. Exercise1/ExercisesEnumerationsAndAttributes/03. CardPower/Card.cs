public class Card
{
    public Card(Rank rank, Suit suit)
    {
        this.Rank = rank;
        this.Suit = suit;
    }

    public Rank Rank { get; set; }

    public Suit Suit { get; set; }

    public override string ToString()
    {
        return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.GetPower(this.Rank, this.Suit)}";
    }

    private int GetPower(Rank rank, Suit suit)
    {
        return (int)rank + (int)suit;
    }
}