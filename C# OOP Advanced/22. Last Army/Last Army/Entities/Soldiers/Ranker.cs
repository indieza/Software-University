using System.Collections.Generic;

public class Ranker : Soldier
{
    private List<string> weaponsAllowed = new List<string>
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(Helmet)
    };

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance, (age + experience) * OutputMessages.RankerMultiply)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed
    {
        get { return this.weaponsAllowed; }
    }

    public override void Regenerate()
    {
        this.Endurance += OutputMessages.RegenerateRanker + this.Age;
    }
}