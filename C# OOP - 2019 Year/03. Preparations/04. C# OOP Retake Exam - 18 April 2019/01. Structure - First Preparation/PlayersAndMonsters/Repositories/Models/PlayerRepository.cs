
namespace PlayersAndMonsters.Repositories.Models
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PlayersAndMonsters.Common;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.NullPlayer);
            }
            if (this.players.Any(p=>p.Username == player.Username))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerAlreadyExist, player.Username));
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = this.players.FirstOrDefault(p => p.Username == username);
            return player;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.NullPlayer);
            }

            this.players.RemoveAll(p => p.Username == player.Username);
            return true;
        }
    }
}