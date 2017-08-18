namespace _01HarestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal class HarvestingFieldsTest
    {
        private static void Main()
        {
            string line = Console.ReadLine();
            Type type = typeof(HarvestingFields);
            FieldInfo[] fieldInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            Dictionary<string, FieldInfo[]> dictionary = new Dictionary<string, FieldInfo[]>
            {
                {
                    "public", fieldInfo.Where(p => p.IsPublic).ToArray()
                },
                {
                    "private", fieldInfo.Where(p => p.IsPrivate).ToArray()
                },
                {
                    "protected", fieldInfo.Where(p => p.IsFamily).ToArray()
                },
                {
                    "all", fieldInfo
                }
            };

            while (line != "HARVEST")
            {
                dictionary[line]
                    .Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}")
                    .ToList()
                    .ForEach(p => Console.WriteLine(p.Replace("family", "protected")));

                line = Console.ReadLine();
            }
        }
    }
}