using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type missionType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(m => m.Name == difficultyLevel);

        return (IMission)Activator.CreateInstance(missionType, neededPoints);
    }
}