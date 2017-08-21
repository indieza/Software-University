using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(m => m.Name == difficultyLevel);
        return (IMission)Activator.CreateInstance(type, neededPoints);
    }
}