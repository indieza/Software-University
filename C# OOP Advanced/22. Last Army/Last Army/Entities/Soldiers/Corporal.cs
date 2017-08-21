using System.Collections.Generic;

public class Corporal : Soldier
{
    private List<string> weaponsAllowed = new List<string>
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(MachineGun),
        nameof(RPG),
        nameof(Helmet),
        nameof(Knife)
    };

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance, (age + experience) * OutputMessages.CorporalMultiply)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed
    {
        get { return this.weaponsAllowed; }
    }

    public override void Regenerate()
    {
        this.Endurance += OutputMessages.RegenerateCorporal + this.Age;
    }
}