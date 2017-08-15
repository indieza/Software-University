namespace _05.FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class FilterByAge
    {
        private static void Main()
        {
            Dictionary<string, int> children = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] items = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string childrenName = items[0];
                int childrenAge = int.Parse(items[1]);
                children.Add(childrenName, childrenAge);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            if (condition == "younger")
            {
                List<bool> sort = children.Select(t => t.Value < age).ToList();
                MakeCheck(children, format, sort);
            }
            else
            {
                List<bool> sort = children.Select(t => t.Value >= age).ToList();
                MakeCheck(children, format, sort);
            }
        }

        private static void MakeCheck(Dictionary<string, int> children, string format, List<bool> sort)
        {
            for (int i = 0; i < sort.Count; i++)
            {
                if (!sort[i])
                {
                    continue;
                }

                if (format == "name")
                {
                    Console.WriteLine(children.ElementAt(i).Key);
                }
                else if (format == "age")
                {
                    Console.WriteLine(children.ElementAt(i).Value);
                }
                else if (format == "name age")
                {
                    Console.WriteLine(children.ElementAt(i).Key + " - " + children.ElementAt(i).Value);
                }
            }
        }
    }
}