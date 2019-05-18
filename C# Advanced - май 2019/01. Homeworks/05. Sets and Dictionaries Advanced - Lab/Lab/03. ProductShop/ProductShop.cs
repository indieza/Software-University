using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    public class ProductShop
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, double>> shops =
                new Dictionary<string, Dictionary<string, double>>();

            string line = Console.ReadLine();

            while (line != "Revision")
            {
                string[] items = line.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string shop = items[0];
                string product = items[1];
                double price = double.Parse(items[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop].Add(product, price);

                line = Console.ReadLine();
            }

            foreach (var shop in shops.OrderBy(sh => sh.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}