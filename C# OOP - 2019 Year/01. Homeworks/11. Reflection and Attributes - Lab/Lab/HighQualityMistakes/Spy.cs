using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);

        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public);

        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance |
            BindingFlags.Public);

        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance |
            BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var publicMethod in privateMethods.Where(s => s.Name.StartsWith("get")))
        {
            sb.AppendLine($"{publicMethod.Name} have to be public!");
        }
        foreach (var publicMethod in publicMethods.Where(s => s.Name.StartsWith("set")))
        {
            sb.AppendLine($"{publicMethod.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }
}