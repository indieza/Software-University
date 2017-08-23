public class Assassin : AbstractHero
{
    private const int AssasinStrength = 25;
    private const int AssasinAgility = 100;
    private const int AssasinIntelligence = 15;
    private const int AssasinHitPoints = 150;
    private const int AssasinDamage = 300;

    public Assassin(string name)
        : base(name, AssasinStrength, AssasinAgility, AssasinIntelligence, AssasinHitPoints, AssasinDamage)
    {
    }
}