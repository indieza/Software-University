public class Axe : Weapon
{
    private const int MinDamage = 5;
    private const int MaxDamage = 10;
    private const int NumberOfSockets = 4;

    public Axe(Rarity rarity, string name)
    : base(rarity, name, MinDamage, MaxDamage, NumberOfSockets)
    {
    }
}