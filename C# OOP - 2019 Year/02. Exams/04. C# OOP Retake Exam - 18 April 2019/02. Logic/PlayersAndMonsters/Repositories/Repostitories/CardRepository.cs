using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayersAndMonsters.Repositories.Repostitories
{
    public class CardRepository : ICardRepository
    {
        private IList<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count
        {
            get
            {
                return this.cards.Count;
            }
        }

        public IReadOnlyCollection<ICard> Cards => this.cards.ToList();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (this.cards.FirstOrDefault(c => c.Name == card.Name) != null)
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            return this.cards.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            this.cards.Remove(card);
            return true;
        }
    }
}