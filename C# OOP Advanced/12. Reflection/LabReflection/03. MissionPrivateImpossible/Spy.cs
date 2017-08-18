using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string inverstingClass)
    {
        StringBuilder sb = new StringBuilder();

        Type type = Type.GetType(inverstingClass);

        MethodInfo[] privateMethodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        sb.AppendLine($"All Private Methods of Class: {inverstingClass}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (MethodInfo info in privateMethodInfos)
        {
            sb.AppendLine(info.Name);
        }

        return sb.ToString().Trim();
    }
}