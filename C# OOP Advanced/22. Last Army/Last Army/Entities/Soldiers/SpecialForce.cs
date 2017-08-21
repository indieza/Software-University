using System.Collections.Generic;
using System.Text;

public class SpecialForce : Soldier
{
    private List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(MachineGun),
            nameof(RPG),
            nameof(Helmet),
            nameof(Knife),
            nameof(NightVision)
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance, (age + experience) * OutputMessages.SpecialForceMultiply)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed
    {
        get { return this.weaponsAllowed; }
    }

    public override void Regenerate()
    {
        this.Endurance += OutputMessages.RegenerateSpecialForce + this.Age;
    }
}