using System;
using System.Linq;
using System.Reflection;

namespace HarvestingFields
{
    public class StartUp
    {
        private static void Main()
        {
            Type type = typeof(HarvestingFields);
            FieldInfo[] fields =
                type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string line = Console.ReadLine();

            while (line != "HARVEST")
            {
                switch (line)
                {
                    case "private":
                        foreach (var field in fields.Where(f => f.Attributes.ToString().ToLower() == "private"))
                        {
                            Console.WriteLine(
                                $"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        }
                        break;

                    case "protected":
                        foreach (var field in fields.Where(f => f.Attributes.ToString().ToLower() == "family"))
                        {
                            Console.WriteLine(
                                $"protected {field.FieldType.Name} {field.Name}");
                        }
                        break;

                    case "public":
                        foreach (var field in fields.Where(f => f.Attributes.ToString().ToLower() == "public"))
                        {
                            Console.WriteLine(
                                $"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        }
                        break;

                    case "all":
                        foreach (var field in fields)
                        {
                            if (field.Attributes.ToString().ToLower() == "family")
                            {
                                Console.WriteLine(
                                    $"protected {field.FieldType.Name} {field.Name}");
                            }
                            else
                            {
                                Console.WriteLine(
                                    $"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                            }
                        }
                        break;

                    default:
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }
}