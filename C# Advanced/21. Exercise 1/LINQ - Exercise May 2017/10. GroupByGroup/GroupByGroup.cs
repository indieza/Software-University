namespace _10.GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class GroupByGroup
    {
        private static void Main()
        {
            var persons = new Dictionary<int, List<string>>();

            string line = Console.ReadLine();

            while (!line.Equals("END"))
            {
                string[] parts = line.Split(' ');
                string fullName = parts[0] + " " + parts[1];
                int group = int.Parse(parts[2]);

                if (persons.ContainsKey(group))
                {
                    persons[group].Add(fullName);
                }
                else
                {
                    persons.Add(group, new List<string>() { fullName });
                }

                line = Console.ReadLine();
            }

            foreach (var item in persons.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key + " - " + string.Join(", ", item.Value));
            }
        }
    }
}