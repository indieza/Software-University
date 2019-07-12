namespace PlayersAndMonsters.Repositories.Contracts
{
    using System.Collections.Generic;

    using Models.Cards.Contracts;

    public interface ICardRepository
    {
        int Count { get; }

        IReadOnlyCollection<ICard> Cards { get; }

        void Add(ICard card);

        bool Remove(ICard card);

        ICard Find(string name);
    }
}
