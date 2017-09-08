using System;
using System.Linq;
using System.Reflection;

public class DriverFactory
{
    public Driver CreateDriver(string driverType, string name, Car car)
    {
        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(p => p.Name == driverType);
        return (Driver)Activator.CreateInstance(type, name, car);
    }
}