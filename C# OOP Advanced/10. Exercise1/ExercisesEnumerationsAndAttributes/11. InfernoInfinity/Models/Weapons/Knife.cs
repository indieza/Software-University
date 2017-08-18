public class Knife : Weapon
{
    private const int MinDamage = 3;
    private const int MaxDamage = 4;
    private const int NumberOfSockets = 2;

    public Knife(Rarity rarity, string name)
        : base(rarity, name, MinDamage, MaxDamage, NumberOfSockets)
    {
    }
}