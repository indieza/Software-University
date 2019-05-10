using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayersAndMonsters.Repositories.Repostitories
{
    public class CardRepository : ICardRepository
    {
        public int Count
        {
            get
            {
                return this.Cards.Count;
            }
        }

        public IReadOnlyCollection<ICard> Cards { get; }

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            foreach (var currentCard in this.Cards)
            {
                if (currentCard.Name == card.Name)
                {
                    throw new ArgumentException($"Card {card.Name} already exists!");
                }
            }

            this.Cards.Append(card);
        }

        public ICard Find(string name)
        {
            return this.Cards.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            this.Cards.ToList().Remove(card);
            return true;
        }
    }
}