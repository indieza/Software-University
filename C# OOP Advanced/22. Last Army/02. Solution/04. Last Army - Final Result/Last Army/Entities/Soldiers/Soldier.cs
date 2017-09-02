using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double MaxEnduranceLevel = 100;
    private const double RegenerateValue = 10;
    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = this.AddWeapons();
    }

    public string Name { get; protected set; }

    public int Age { get; protected set; }

    public double Experience { get; protected set; }

    public double Endurance
    {
        get { return this.endurance; }
        protected set { this.endurance = Math.Min(value, MaxEnduranceLevel); }
    }

    public virtual double OverallSkill => this.Age + this.Experience;

    public IDictionary<string, IAmmunition> Weapons { get; protected set; }

    private IDictionary<string, IAmmunition> AddWeapons()
    {
        Dictionary<string, IAmmunition> weapons = new Dictionary<string, IAmmunition>();

        foreach (var weapon in this.WeaponsAllowed)
        {
            weapons.Add(weapon, null);
        }

        return weapons;
    }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public virtual void Regenerate()
    {
        this.Endurance += this.Age + RegenerateValue;
    }

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
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;
        this.AmmunitionRevision(mission.WearLevelDecrement);
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