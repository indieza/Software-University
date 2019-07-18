
namespace PlayersAndMonsters.Repositories.Models
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;
        public CardRepository()
        {
            this.cards = new List<ICard>();
        }
        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.NullCard);
            }
            if (this.cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CardAlreadyExist, card.Name));
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            ICard card = this.cards.FirstOrDefault(c => c.Name == name);
            return card;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.NullCard);
            }

            this.cards.RemoveAll(c => c.Name == card.Name);
            return true;
        }
    }
}