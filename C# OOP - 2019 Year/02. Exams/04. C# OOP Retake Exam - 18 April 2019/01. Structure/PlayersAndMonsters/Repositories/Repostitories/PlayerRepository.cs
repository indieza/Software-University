using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Repositories.Repostitories
{
    public class PlayerRepository : IPlayerRepository
    {
        public int Count { get; private set; }

        public IReadOnlyCollection<IPlayer> Players => throw new NotImplementedException();

        public void Add(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public IPlayer Find(string username)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}