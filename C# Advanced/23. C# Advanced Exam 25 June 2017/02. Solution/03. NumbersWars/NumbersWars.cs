using System;
using System.Collections.Generic;
using System.Linq;

internal class NumbersWars
{
    public static readonly string Alphabet = "#abcdefghijklmnopqrstuvwxyz";

    private static void Main()
    {
        string[] line1 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] line2 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Queue<Card> playerOneDeck = new Queue<Card>();
        Queue<Card> playerTwoDeck = new Queue<Card>();

        foreach (string s in line1)
        {
            int digit = int.Parse(s.Substring(0, s.Length - 1));
            string letter = s.Substring(s.Length - 1);
            playerOneDeck.Enqueue(new Card(digit, letter));
        }

        foreach (string s in line2)
        {
            int digit = int.Parse(s.Substring(0, s.Length - 1));
            string letter = s.Substring(s.Length - 1);
            playerTwoDeck.Enqueue(new Card(digit, letter));
        }

        int turns = 0;

        bool outOfCards = false;
        bool draw = false;

        while (turns < 1000000 && playerOneDeck.Count > 0 && playerTwoDeck.Count > 0)
        {
            if (turns > 10000)
            {
                turns = 1000000;
                break;
            }

            List<Card> playedCards = new List<Card>();

            Card playerOneCard = playerOneDeck.Dequeue();
            Card playerTwoCard = playerTwoDeck.Dequeue();

            playedCards.Add(playerOneCard);
            playedCards.Add(playerTwoCard);

            if (playerOneCard.Digit > playerTwoCard.Digit)
            {
                foreach (Card card in playedCards.OrderByDescending(c => c.Digit).ThenByDescending(c => c.Name))
                {
                    playerOneDeck.Enqueue(card);
                }
            }
            else if (playerOneCard.Digit < playerTwoCard.Digit)
            {
                foreach (Card card in playedCards.OrderByDescending(c => c.Digit).ThenByDescending(c => c.Name))
                {
                    playerTwoDeck.Enqueue(card);
                }
            }
            else
            {
                bool haveWinner = false;

                if (playerOneDeck.Count - 3 < 0 || playerTwoDeck.Count - 3 < 0)
                {
                    haveWinner = true;
                    outOfCards = true;

                    if (playerOneDeck.Count == playerTwoDeck.Count)
                    {
                        draw = true;
                    }
                }

                while (haveWinner == false)
                {
                    if (playerOneDeck.Count - 3 < 0 || playerTwoDeck.Count - 3 < 0)
                    {
                        outOfCards = true;

                        if (playerOneDeck.Count == playerTwoDeck.Count)
                        {
                            draw = true;
                        }

                        break;
                    }

                    List<Card> playerOneDrawCards = new List<Card>();
                    List<Card> playerTwoDrawCards = new List<Card>();

                    for (int i = 0; i < 3; i++)
                    {
                        playerOneDrawCards.Add(playerOneDeck.Dequeue());
                        playerTwoDrawCards.Add(playerTwoDeck.Dequeue());
                    }

                    int drawResult = GetDrawWinner(playerOneDrawCards, playerTwoDrawCards);

                    playedCards.AddRange(playerOneDrawCards);
                    playedCards.AddRange(playerTwoDrawCards);

                    if (drawResult == 1)
                    {
                        haveWinner = true;

                        foreach (Card card in playedCards.OrderByDescending(c => c.Digit).ThenByDescending(c => c.Name))
                        {
                            playerOneDeck.Enqueue(card);
                        }
                    }
                    else if (drawResult == 2)
                    {
                        haveWinner = true;

                        foreach (Card card in playedCards.OrderByDescending(c => c.Digit).ThenByDescending(c => c.Name))
                        {
                            playerTwoDeck.Enqueue(card);
                        }
                    }
                }
            }

            turns++;

            if (outOfCards)
            {
                break;
            }
        }
        if (draw)
        {
            Console.WriteLine($"Draw after {turns} turns");
        }
        else
        {
            Console.WriteLine(playerOneDeck.Count > playerTwoDeck.Count
                ? $"First player wins after {turns} turns"
                : $"Second player wins after {turns} turns");
        }
    }

    private static int GetDrawWinner(List<Card> firstDeck, List<Card> secondDeck)
    {
        string playerOneChars = string.Join(string.Empty, firstDeck.Select(c => c.Name)).ToLower();
        string playerTwoChars = string.Join(string.Empty, secondDeck.Select(c => c.Name)).ToLower();

        int playerOneSum = 0;
        int playerTwoSum = 0;

        for (int i = 0; i < playerOneChars.Length; i++)
        {
            int number = Alphabet.IndexOf(playerOneChars[i]);
            playerOneSum += number;
        }

        for (int i = 0; i < playerTwoChars.Length; i++)
        {
            int number = Alphabet.IndexOf(playerTwoChars[i]);
            playerTwoSum += number;
        }

        if (playerOneSum > playerTwoSum)
        {
            return 1;
        }

        if (playerOneSum < playerTwoSum)
        {
            return 2;
        }

        return 0;
    }
}

internal class Card
{
    public Card(int digit, string name)
    {
        this.Digit = digit;
        this.Name = name;
    }

    public int Digit { get; set; }

    public string Name { get; set; }
}