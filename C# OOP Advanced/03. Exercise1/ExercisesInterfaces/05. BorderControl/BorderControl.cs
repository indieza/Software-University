using System;
using System.Collections.Generic;

namespace _05.BorderControl
{
    internal class BorderControl
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            IList<IContolable> city = new List<IContolable>();

            while (line != "End")
            {
                string[] items = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (items.Length == 3)
                {
                    city.Add(new Citizen(items[0], int.Parse(items[1]), items[2]));
                }
                else
                {
                    city.Add(new Robot(items[0], items[1]));
                }

                line = Console.ReadLine();
            }

            string code = Console.ReadLine();

            IList<string> codes = CheckCodes(city, code);
            Console.WriteLine(string.Join(Environment.NewLine, codes));
        }

        private static IList<string> CheckCodes(IList<IContolable> city, string code)
        {
            IList<string> codes = new List<string>();

            foreach (var c in city)
            {
                string id = c.Id;

                if (id.EndsWith(code))
                {
                    codes.Add(id);
                }
            }

            return codes;
        }
    }
}