using System.Collections.Generic;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods.Contracts
{
    public interface INeighbourhood
    {
        void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers);
    }
}