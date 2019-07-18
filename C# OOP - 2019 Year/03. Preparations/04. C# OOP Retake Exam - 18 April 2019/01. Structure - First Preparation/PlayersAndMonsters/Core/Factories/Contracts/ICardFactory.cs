namespace PlayersAndMonsters.Core.Factories.Contracts
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public interface ICardFactory
    {
        ICard CreateCard(string type, string name);
    }
}
