namespace _13.OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class OfficeStuff
    {
        private static void Main()
        {
            var companies = new Dictionary<string, Dictionary<string, int>>();

            int inputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputs; i++)
            {
                string[] info = Console.ReadLine().Split(new[] { ' ', '|', '-' }, StringSplitOptions.RemoveEmptyEntries);

                string company = info[0];
                int amoung = int.Parse(info[1]);
                string product = info[2];

                if (companies.ContainsKey(company))
                {
                    if (companies[company].ContainsKey(product))
                    {
                        companies[company][product] += amoung;
                    }
                    else
                    {
                        companies[company].Add(product, amoung);
                    }
                }
                else
                {
                    companies.Add(company, new Dictionary<string, int>());
                    companies[company].Add(product, amoung);
                }
            }

            foreach (var item in companies.OrderBy(x => x.Key))
            {
                Console.Write(item.Key + ": ");
                Console.Write(string.Join(", ", item.Value.Select(x => x.Key + "-" + x.Value).ToList()));
                Console.WriteLine();
            }
        }
    }
}