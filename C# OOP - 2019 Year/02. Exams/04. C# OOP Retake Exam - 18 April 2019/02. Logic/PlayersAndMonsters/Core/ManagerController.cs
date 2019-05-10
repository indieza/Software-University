namespace PlayersAndMonsters.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Factories;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Repostitories;
    using System.Linq;
    using PlayersAndMonsters.Models.Cards.Cards;

    public class ManagerController : IManagerController
    {
        private IList<IPlayer> players;
        private IList<ICard> cards;
        private PlayerFactory playerFactory;
        private CardFactory cardFactory;

        public ManagerController()
        {
            this.players = new List<IPlayer>();
            this.cards = new List<ICard>();
            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);
            this.players.Add(player);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);
            this.cards.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            this.players
                .FirstOrDefault(p => p.Username == username)
                .CardRepository
                .Add(this.cards.FirstOrDefault(c => c.Name == cardName));

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}