namespace PlayersAndMonsters.Core
{
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Cards.Models;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Players.Models;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Repositories.Models;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository playerRepository;
        private readonly ICardRepository cardRepository;
        private readonly IBattleField battleField;

        public ManagerController()
        {
            this.playerRepository = new PlayerRepository();
            this.cardRepository = new CardRepository();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = null;

            switch (type)
            {
                case "Beginner":
                    player = new Beginner(new CardRepository(), username);
                    break;

                case "Advanced":
                    player = new Advanced(new CardRepository(), username);
                    break;

                default:
                    break;
            }

            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = null;

            switch (type)
            {
                case "Trap":
                    card = new TrapCard(name);
                    break;

                case "Magic":
                    card = new MagicCard(name);
                    break;

                default:
                    break;
            }

            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards,
                card.Name,
                player.Username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            return string.Format(ConstantMessages.FightInfo,
                attacker.Health,
                enemy.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IPlayer player in this.playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo,
                    player.Username,
                    player.Health,
                    player.CardRepository.Cards.Count));

                foreach (ICard card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo,
                        card.Name,
                        card.DamagePoints));
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}