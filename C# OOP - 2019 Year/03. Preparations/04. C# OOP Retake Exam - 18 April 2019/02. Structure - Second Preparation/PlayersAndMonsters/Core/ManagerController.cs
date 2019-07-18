namespace PlayersAndMonsters.Core
{
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Models;
    using PlayersAndMonsters.Models.BattleFields.Models;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Models;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private readonly PlayerRepository players;
        private readonly CardRepository cards;
        private readonly PlayerFactory playerFactory;
        private readonly CardFactory cardFactory;
        private readonly BattleField battleField;

        public ManagerController()
        {
            this.players = new PlayerRepository();
            this.cards = new CardRepository();
            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
            this.battleField = new BattleField();
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
            IPlayer player = this.players.Find(username);
            ICard card = this.cards.Find(cardName);
            player.CardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.players.Find(attackUser);
            IPlayer enemy = this.players.Find(enemyUser);
            this.battleField.Fight(attacker, enemy);
            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IPlayer player in this.players.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo,
                    player.Username,
                    player.Health,
                    player.CardRepository.Cards.Count));

                foreach (ICard card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}