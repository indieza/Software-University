namespace PlayersAndMonsters.Models.Cards.Contracts
{
    public interface ICard
    {
        string Name { get; }

        int DamagePoints { get; set; }

        int HealthPoints { get; }
    }
}
