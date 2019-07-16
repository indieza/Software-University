using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);

        var fields = classType.GetFields(BindingFlags.Instance | 
            BindingFlags.Static |
            BindingFlags.NonPublic | 
            BindingFlags.Public)
                .Where(f => requestedFields.Contains(f.Name));

        StringBuilder sb = new StringBuilder();

        object classInstance = Activator.CreateInstance(classType, new object[] { });


        sb.AppendLine($"Class under investigation: {classType}");

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}