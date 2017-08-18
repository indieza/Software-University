namespace _05.CardCompareTo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class CardCompareTo
    {
        private static void Main()
        {
            SortedSet<Card> cards = new SortedSet<Card>();
            Rank card1Rank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
            Suit card1Suit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());
            Card card1 = new Card(card1Rank, card1Suit);
            cards.Add(card1);

            Rank card2Rank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
            Suit card2Suit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());
            Card card2 = new Card(card2Rank, card2Suit);
            cards.Add(card2);

            Console.WriteLine(cards.Last().ToString());
        }
    }
}