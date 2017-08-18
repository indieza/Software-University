namespace _02.CardRank
{
    using System;

    internal class CardRankStartUp
    {
        private static void Main()
        {
            Array deck = typeof(Rank).GetEnumValues();

            Console.WriteLine("Card Ranks:");

            foreach (var card in deck)
            {
                Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");
            }
        }
    }
}