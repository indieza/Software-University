public class EmeraldGem : Gem
{
    private const int Strength = 1;
    private const int Agility = 4;
    private const int Vitality = 9;

    public EmeraldGem(Clarity clarity)
        : base(clarity, Strength, Agility, Vitality)
    {
    }
}