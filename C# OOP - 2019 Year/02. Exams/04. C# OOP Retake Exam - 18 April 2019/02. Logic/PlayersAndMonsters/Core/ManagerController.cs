namespace PlayersAndMonsters.Core
{
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Factories;
    using PlayersAndMonsters.Models.BattleFields.Field;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Repostitories;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private readonly CardRepository cardRepository;
        private readonly PlayerRepository playerRepository;
        private readonly PlayerFactory playerFactory;
        private readonly CardFactory cardFactory;
        private readonly BattleField field;

        public ManagerController()
        {
            this.cardRepository = new CardRepository();
            this.playerRepository = new PlayerRepository();
            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
            this.field = new BattleField();
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
            playerRepository.Find(username).CardRepository.Add(this.cardRepository.Find(cardName));

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            this.field.Fight(attacker, enemy);

            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}