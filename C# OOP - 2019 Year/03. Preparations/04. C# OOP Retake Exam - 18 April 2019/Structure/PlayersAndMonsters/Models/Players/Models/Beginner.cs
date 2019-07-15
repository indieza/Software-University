
namespace PlayersAndMonsters.Models.Players.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PlayersAndMonsters.Repositories.Contracts;

    public class Beginner : Player
    {
        private const int InitialHealthPoints = 50;

        public Beginner(ICardRepository cardRepository, string username)
            : base(cardRepository, username, InitialHealthPoints)
        {
        }
    }
}