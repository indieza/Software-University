
namespace PlayersAndMonsters.Core.Factories.Models
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Players.Models;
    using PlayersAndMonsters.Repositories.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;

            switch (type)
            {
                case "Advanced":
                    player = new Advanced(new CardRepository(), username);
                    break;
                case "Beginner":
                    player = new Beginner(new CardRepository(), username);
                    break;
                default:
                    break;
            }

            return player;
        }
    }
}