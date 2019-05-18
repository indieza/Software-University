using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    public class Wardrobe
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string[] items = line.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string color = items[0];
                string[] clothes = items[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color].Add(cloth, 0);
                    }

                    wardrobe[color][cloth]++;
                }
            }

            string[] find = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string colorFind = find[0];
            string clothFind = find[1];

            foreach (var cloth in wardrobe)
            {
                Console.WriteLine($"{cloth.Key} clothes:");

                foreach (var product in cloth.Value)
                {
                    if (cloth.Key == colorFind && product.Key == clothFind)
                    {
                        Console.WriteLine($"* {product.Key} - {product.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {product.Key} - {product.Value}");
                    }
                }
            }
        }
    }
}