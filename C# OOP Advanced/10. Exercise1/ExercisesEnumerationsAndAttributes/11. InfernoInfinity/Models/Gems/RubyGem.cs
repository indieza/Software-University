public class RubyGem : Gem
{
    private const int Strength = 7;
    private const int Agility = 2;
    private const int Vitality = 5;

    public RubyGem(Clarity clarity)
        : base(clarity, Strength, Agility, Vitality)
    {
    }
}