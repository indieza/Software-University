using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players.Players
{
    public class Beginner : Player
    {
        private const int initialHealthPoints = 50;

        public Beginner(ICardRepository cardRepository, string username)
            : base(cardRepository, username, initialHealthPoints)
        {
        }
    }
}