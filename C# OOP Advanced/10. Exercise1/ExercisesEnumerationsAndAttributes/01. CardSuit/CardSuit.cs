namespace _01.CardSuit
{
    using System;

    internal class CardSuit
    {
        private static void Main()
        {
            Array deck = Enum.GetValues(typeof(Suit));

            Console.WriteLine("Card Suits:");

            foreach (var card in deck)
            {
                Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");
            }
        }
    }
}