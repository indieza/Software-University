namespace PlayersAndMonsters.Repositories.Contracts
{
    using Models.Cards.Contracts;
    using System.Collections.Generic;

    public interface ICardRepository
    {
        int Count { get; }

        IReadOnlyCollection<ICard> Cards { get; }

        void Add(ICard card);

        bool Remove(ICard card);

        ICard Find(string name);
    }
}