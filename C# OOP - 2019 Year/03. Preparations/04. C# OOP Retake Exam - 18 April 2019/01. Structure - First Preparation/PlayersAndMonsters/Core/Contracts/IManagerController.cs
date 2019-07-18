namespace PlayersAndMonsters.Core.Contracts
{
    public interface IManagerController
    {
        string AddPlayer(string type, string username);

        string AddCard(string type, string name);

        string AddPlayerCard(string username, string cardName);

        string Fight(string attackUser, string enemyUser);

        string Report();
    }
}
