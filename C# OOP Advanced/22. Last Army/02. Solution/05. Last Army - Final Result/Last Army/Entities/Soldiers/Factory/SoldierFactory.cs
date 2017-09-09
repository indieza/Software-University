using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type soldierType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(m => m.Name == soldierTypeName);

        return (ISoldier)Activator.CreateInstance(soldierType, name, age, experience, endurance);
    }
}