using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players.Players
{
    public class Advanced : Player
    {
        private const int initialHealthPoints = 250;

        public Advanced(ICardRepository cardRepository, string username)
            : base(cardRepository, username, initialHealthPoints)
        {
        }
    }
}