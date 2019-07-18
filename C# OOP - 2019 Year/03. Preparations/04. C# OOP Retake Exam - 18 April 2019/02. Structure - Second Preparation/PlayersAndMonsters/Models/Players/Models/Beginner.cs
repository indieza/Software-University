namespace PlayersAndMonsters.Models.Players.Models
{
    using PlayersAndMonsters.Repositories.Contracts;

    public class Beginner : Player
    {
        private const int InitialhealthPoints = 50;

        public Beginner(ICardRepository cardRepository, string username)
            : base(cardRepository, username, InitialhealthPoints)
        {
        }
    }
}