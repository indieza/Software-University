using System;
using System.Linq;
using System.Reflection;

public class HarvesterFactory
{
    public Harvester CreateNewHammerHarvester(string harvesterType, string id, double oreOutput, double energyRequirement)
    {
        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == harvesterType);

        return (Harvester)Activator.CreateInstance(type, id, oreOutput, energyRequirement);
    }

    public Harvester CreateNewSonicHarvester(string harvesterType, string id, double oreOutput, double energyRequirement, int sonicFactor)
    {
        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == harvesterType);

        return (Harvester)Activator.CreateInstance(type, id, oreOutput, energyRequirement, sonicFactor);
    }
}