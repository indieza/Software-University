using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayersAndMonsters.Repositories.Repostitories
{
    public class PlayerRepository : IPlayerRepository
    {
        public int Count
        {
            get
            {
                return this.Players.Count;
            }
        }

        public IReadOnlyCollection<IPlayer> Players { get; }

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (this.Players.FirstOrDefault(p => p.Username == player.Username) != null)
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.Players.Append(player);
        }

        public IPlayer Find(string username)
        {
            return this.Players.FirstOrDefault(p => p.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            this.Players.ToList().Remove(player);

            return true;
        }
    }
}