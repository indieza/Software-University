using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance, double overrallSkill)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.OverallSkill = overrallSkill;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public double Experience { get; set; }

    public double Endurance
    {
        get { return this.endurance; }
        set { this.endurance = Math.Min(value, OutputMessages.MaxEnduranceLevel); }
    }

    public double OverallSkill { get; set; }

    public IDictionary<string, IAmmunition> Weapons { get; set; }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public abstract void Regenerate();

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    public void CompleteMission(IMission mission)
    {
        throw new System.NotImplementedException();
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}