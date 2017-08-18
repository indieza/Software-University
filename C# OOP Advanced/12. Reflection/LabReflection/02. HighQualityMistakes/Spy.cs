using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string inverstingClass)
    {
        StringBuilder sb = new StringBuilder();

        Type type = Type.GetType(inverstingClass);

        FieldInfo[] fieldInfos = type
            .GetFields(BindingFlags.Instance |
                       BindingFlags.Static |
                       BindingFlags.Public);

        MethodInfo[] publicMethodInfos = type
            .GetMethods(BindingFlags.Instance | BindingFlags.Public);

        MethodInfo[] privateMethodInfos = type
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo field in fieldInfos)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo field in privateMethodInfos.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{field.Name} have to be public!");
        }

        foreach (MethodInfo field in publicMethodInfos.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{field.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }
}