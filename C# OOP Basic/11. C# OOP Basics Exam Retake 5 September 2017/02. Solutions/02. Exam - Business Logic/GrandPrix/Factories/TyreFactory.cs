using System;
using System.Linq;
using System.Reflection;

public class TyreFactory
{
    public Tyre CreateUltrasoftTyre(string tyreType, double hardness, double grip)
    {
        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(p => p.Name == tyreType);
        return (Tyre)Activator.CreateInstance(type, hardness, grip);
    }

    public Tyre CreateHardTyre(string tyreType, double hardness)
    {
        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(p => p.Name == tyreType);
        return (Tyre)Activator.CreateInstance(type, hardness);
    }
}