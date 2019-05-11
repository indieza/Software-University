using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Repostitories;
using System;
using System.Linq;
using System.Reflection;

namespace PlayersAndMonsters.Core.Factories.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type player = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(n => n.Name == type);

            return (IPlayer)Activator.CreateInstance(player, new CardRepository(), username);
        }
    }
}