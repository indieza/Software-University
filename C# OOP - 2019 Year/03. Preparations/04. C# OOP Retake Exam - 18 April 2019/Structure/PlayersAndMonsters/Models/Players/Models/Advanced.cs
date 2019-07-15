
namespace PlayersAndMonsters.Models.Players.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PlayersAndMonsters.Repositories.Contracts;

    public class Advanced : Player
    {
        private const int InitialHealthPoints = 250;

        public Advanced(ICardRepository cardRepository, string username)
            : base(cardRepository, username, InitialHealthPoints)
        {
        }
    }
}