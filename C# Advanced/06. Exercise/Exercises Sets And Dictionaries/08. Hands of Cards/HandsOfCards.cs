namespace _08_Hands_of_Cards
{
    using System;
    using System.Collections.Generic;

    internal class HandsOfCards
    {
        private static void Main()
        {
            Dictionary<string, int> cardPowers = GetCardPowers();
            Dictionary<char, int> cardTypes = GetCardTypes();

            Dictionary<string, HashSet<string>> playerCards = new Dictionary<string, HashSet<string>>();

            string input;

            while ((input = Console.ReadLine()) != "JOKER")
            {
                string[] data = input.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                char[] separators = ", ".ToCharArray();

                string player = data[0];
                string[] cards = data[1].Split(separators, StringSplitOptions.RemoveEmptyEntries);

                HashSet<string> uniqueCards = new HashSet<string>();

                if (playerCards.ContainsKey(player))
                {
                    uniqueCards = playerCards[player];
                }

                foreach (var card in cards)
                {
                    uniqueCards.Add(card);
                }

                playerCards[player] = uniqueCards;
            }

            foreach (var pair in playerCards)
            {
                Console.WriteLine("{0}: {1}", pair.Key, GetCardsValue(pair.Value, cardPowers, cardTypes));
            }
        }

        private static int GetCardsValue(HashSet<string> cards, Dictionary<string, int> cardPowers, Dictionary<char, int> cardTypes)
        {
            int cardsValue = 0;

            foreach (var card in cards)
            {
                string power = card.Substring(0, card.Length - 1);
                char type = card[card.Length - 1];
                cardsValue += cardPowers[power] * cardTypes[type];
            }

            return cardsValue;
        }

        private static Dictionary<string, int> GetCardPowers()
        {
            Dictionary<string, int> cardPowers = new Dictionary<string, int>();
            for (int i = 2; i <= 10; i++)
            {
                cardPowers[i.ToString()] = i;
            }

            cardPowers["J"] = 11;
            cardPowers["Q"] = 12;
            cardPowers["K"] = 13;
            cardPowers["A"] = 14;

            return cardPowers;
        }

        private static Dictionary<char, int> GetCardTypes()
        {
            Dictionary<char, int> cardTypes = new Dictionary<char, int>();
            cardTypes['S'] = 4;
            cardTypes['H'] = 3;
            cardTypes['D'] = 2;
            cardTypes['C'] = 1;

            return cardTypes;
        }
    }
}