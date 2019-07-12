namespace PlayersAndMonsters.Core.Factories.Models
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Cards.Models;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;

            switch (type)
            {
                case "Magic":
                    card = new MagicCard(name);
                    break;

                case "Trap":
                    card = new TrapCard(name);
                    break;

                default:
                    break;
            }

            return card;
        }
    }
}