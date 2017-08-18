using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string inverstingClass)
    {
        StringBuilder sb = new StringBuilder();

        Type type = Type.GetType(inverstingClass);

        MethodInfo[] methodInfos = type
            .GetMethods(BindingFlags.Instance |
                        BindingFlags.NonPublic |
                        BindingFlags.Public);

        foreach (var info in methodInfos.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{info.Name} will return {info.ReturnType}");
        }

        foreach (var info in methodInfos.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{info.Name} will set field of {info.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}