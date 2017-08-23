using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IAmmunitionFactory ammunitionFactory;
    private Dictionary<string, int> ammunitionQuantites;

    public WareHouse()
    {
        this.ammunitionFactory = new AmmunitionFactory();
        this.ammunitionQuantites = new Dictionary<string, int>();
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool isEquip = true;

        List<string> missingWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();

        foreach (var missingWeaponName in missingWeapons)
        {
            if (this.ammunitionQuantites.ContainsKey(missingWeaponName) && this.ammunitionQuantites[missingWeaponName] > 0)
            {
                soldier.Weapons[missingWeaponName] = this.ammunitionFactory.CreateAmmunition(missingWeaponName);
                this.ammunitionQuantites[missingWeaponName]--;
            }
            else
            {
                isEquip = false;
            }
        }

        return isEquip;
    }

    public void AddAmmunitions(string name, int quantity)
    {
        if (!this.ammunitionQuantites.ContainsKey(name))
        {
            this.ammunitionQuantites[name] = 0;
        }

        this.ammunitionQuantites[name] += quantity;
    }
}