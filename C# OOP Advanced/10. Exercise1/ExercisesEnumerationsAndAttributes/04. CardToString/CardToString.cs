namespace _04.CardToString
{
    using System;

    internal class CardToString
    {
        private static void Main()
        {
            Rank cardRank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
            Suit cardSuit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());
            Card card = new Card(cardRank, cardSuit);

            Console.WriteLine(card.ToString());
        }
    }
}