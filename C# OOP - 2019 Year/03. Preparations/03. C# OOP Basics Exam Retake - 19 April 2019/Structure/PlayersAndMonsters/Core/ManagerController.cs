namespace PlayersAndMonsters.Core
{
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Models;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Models;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private readonly PlayerRepository playerRepository;
        private readonly PlayerFactory playerFactory;
        private readonly CardRepository cardRepository;
        private readonly CardFactory cardFactory;
        private readonly BattleField battleField;

        public ManagerController()
        {
            this.playerRepository = new PlayerRepository();
            this.playerFactory = new PlayerFactory();
            this.cardRepository = new CardRepository();
            this.cardFactory = new CardFactory();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);
            player.CardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = this.playerRepository.Find(attackUser);
            IPlayer enemyPlayer = this.playerRepository.Find(enemyUser);
            this.battleField.Fight(attackPlayer, enemyPlayer);
            return string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IPlayer player in this.playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo,
                    player.Username, player.Health,
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