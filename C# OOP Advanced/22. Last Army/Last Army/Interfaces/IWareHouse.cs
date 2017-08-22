public interface IWareHouse
{
    void EquipArmy(IArmy army);

    void AddAmmunitions(string name, int quantity);

    bool TryEquipSoldier(ISoldier soldier);
}