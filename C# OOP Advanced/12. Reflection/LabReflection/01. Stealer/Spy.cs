using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string inverstingClass, params string[] requestedFields)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(inverstingClass);
        FieldInfo[] classField = classType
            .GetFields(BindingFlags.Instance |
                       BindingFlags.Static |
                       BindingFlags.NonPublic |
                       BindingFlags.Public);

        object classInstance = Activator.CreateInstance(classType);
        sb.AppendLine($"Class under investigation: {inverstingClass}");

        foreach (FieldInfo field in classField.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}