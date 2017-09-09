using System;
using System.Linq;
using System.Reflection;

public class ProviderFactory
{
    public Provider CreateNewProvider(string providerType, string id, double energyOutput)
    {
        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == providerType);

        return (Provider)Activator.CreateInstance(type, id, energyOutput);
    }
}