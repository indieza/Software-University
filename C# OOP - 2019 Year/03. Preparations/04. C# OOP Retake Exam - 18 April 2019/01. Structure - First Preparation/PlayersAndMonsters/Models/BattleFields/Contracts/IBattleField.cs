namespace PlayersAndMonsters.Models.BattleFields.Contracts
{
    using Players.Contracts;

    public interface IBattleField
    {
        void Fight(IPlayer attackPlayer, IPlayer enemyPlayer);
    }
}
