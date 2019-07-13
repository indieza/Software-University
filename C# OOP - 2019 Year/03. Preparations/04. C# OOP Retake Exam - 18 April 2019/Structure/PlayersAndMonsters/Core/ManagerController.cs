namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;

    public class ManagerController : IManagerController
    {
        public ManagerController()
        {
        }

        public string AddPlayer(string type, string username)
        {
            throw new NotImplementedException();
        }

        public string AddCard(string type, string name)
        {
            throw new NotImplementedException();
        }

        public string AddPlayerCard(string username, string cardName)
        {
            throw new NotImplementedException();
        }

        public string Fight(string attackUser, string enemyUser)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
