using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type ammunitionType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(a => a.Name == ammunitionName);

        return (IAmmunition)Activator.CreateInstance(ammunitionType, ammunitionName);
    }
}