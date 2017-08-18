using System;

public class Card : IComparable<Card>
{
    public Card(Rank rank, Suit suit)
    {
        this.Rank = rank;
        this.Suit = suit;
    }

    public Rank Rank { get; set; }

    public Suit Suit { get; set; }

    public int CompareTo(Card other)
    {
        return this.GetPower(this.Rank, this.Suit).CompareTo(other.GetPower(other.Rank, other.Suit));
    }

    public int GetPower(Rank rank, Suit suit)
    {
        return (int)rank + (int)suit;
    }

    public override string ToString()
    {
        return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.GetPower(this.Rank, this.Suit)}";
    }
}