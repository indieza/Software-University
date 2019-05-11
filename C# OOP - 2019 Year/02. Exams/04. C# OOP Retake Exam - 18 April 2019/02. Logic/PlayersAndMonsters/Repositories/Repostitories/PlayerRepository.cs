using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayersAndMonsters.Repositories.Repostitories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IList<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count
        {
            get
            {
                return this.Players.Count;
            }
        }

        public IReadOnlyCollection<IPlayer> Players => this.players.ToList();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (this.players.FirstOrDefault(p => p.Username == player.Username) != null)
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
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