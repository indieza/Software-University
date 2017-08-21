using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(w => w.Name == ammunitionName);

        return (IAmmunition)Activator.CreateInstance(type, ammunitionName);
    }
}