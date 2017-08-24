using System;
using System.Collections.Generic;
using System.Linq;

internal class NumberWars
{
    public static readonly string Alphabet = "#abcdefghijklmnopqrstuvwxyz";

    private static void Main()
    {
        var turns = 0;
        bool draw = false;

        Queue<Card> playerOneDeck = new Queue<Card>();
        Queue<Card> playerTwoDeck = new Queue<Card>();

        var playerOneInputLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var playerTwoInputLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var card in playerOneInputLine)
        {
            int digit = int.Parse(card.Substring(0, card.Length - 1));
            string letter = card.Substring(card.Length - 1);
            playerOneDeck.Enqueue(new Card(digit, letter));
        }

        foreach (var card in playerTwoInputLine)
        {
            int digit = int.Parse(card.Substring(0, card.Length - 1));
            string letter = card.Substring(card.Length - 1);
            playerTwoDeck.Enqueue(new Card(digit, letter));
        }

        bool outOfcards = false;

        while (turns < 1000000 && playerOneDeck.Count > 0 && playerTwoDeck.Count > 0)
        {
            if (turns > 10000)
            {
                turns = 1000000;
                break;
            }

            List<Card> playedCards = new List<Card>();

            var playerOneCard = playerOneDeck.Dequeue();
            var playerTwoCard = playerTwoDeck.Dequeue();

            playedCards.Add(playerOneCard);
            playedCards.Add(playerTwoCard);

            if (playerOneCard.Digit > playerTwoCard.Digit)
            {
                foreach (var card in playedCards.OrderByDescending(x => x.Digit).ThenByDescending(c => c.Name))
                {
                    playerOneDeck.Enqueue(card);
                }
            }
            else if (playerOneCard.Digit < playerTwoCard.Digit)
            {
                foreach (var card in playedCards.OrderByDescending(x => x.Digit).ThenByDescending(c => c.Name))
                {
                    playerTwoDeck.Enqueue(card);
                }
            }
            else
            {
                var haveWinner = false;

                if (playerOneDeck.Count - 3 < 0 || playerTwoDeck.Count - 3 < 0)
                {
                    haveWinner = true;
                    outOfcards = true;

                    if (playerOneDeck.Count == playerTwoDeck.Count)
                    {
                        draw = true;
                    }
                }

                while (haveWinner == false)
                {
                    if (playerOneDeck.Count - 3 < 0 || playerTwoDeck.Count - 3 < 0)
                    {
                        outOfcards = true;

                        if (playerOneDeck.Count == playerTwoDeck.Count)
                        {
                            draw = true;
                        }

                        break;
                    }

                    List<Card> p1DrawCards = new List<Card>();
                    List<Card> p2DrawCards = new List<Card>();

                    for (int k = 0; k < 3; k++)
                    {
                        p1DrawCards.Add(playerOneDeck.Dequeue());
                        p2DrawCards.Add(playerTwoDeck.Dequeue());
                    }

                    var drawResult = GetDrawWinner(p1DrawCards, p2DrawCards);

                    playedCards.AddRange(p1DrawCards);
                    playedCards.AddRange(p2DrawCards);

                    if (drawResult == 1)
                    {
                        haveWinner = true;

                        foreach (var card in playedCards.OrderByDescending(x => x.Digit).ThenByDescending(c => c.Name))
                        {
                            playerOneDeck.Enqueue(card);
                        }
                    }
                    else if (drawResult == 2)
                    {
                        haveWinner = true;
                        foreach (var card in playedCards.OrderByDescending(x => x.Digit).ThenByDescending(c => c.Name))
                        {
                            playerTwoDeck.Enqueue(card);
                        }
                    }
                }
            }

            turns++;

            if (outOfcards)
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

    private static int GetDrawWinner(List<Card> playerOneDrawCards, List<Card> playerTwoDrawCards)
    {
        string playerOneChar = string.Join(string.Empty, playerOneDrawCards.Select(x => x.Name)).ToLower();
        string playerTwoChar = string.Join(string.Empty, playerTwoDrawCards.Select(x => x.Name)).ToLower();

        var playerOneSum = 0;
        var playerTwoSum = 0;

        for (int i = 0; i < playerOneChar.Length; i++)
        {
            var num = Alphabet.IndexOf(playerOneChar[i]);
            playerOneSum += num;
        }

        for (int i = 0; i < playerOneChar.Length; i++)
        {
            var num = Alphabet.IndexOf(playerTwoChar[i]);
            playerTwoSum += num;
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