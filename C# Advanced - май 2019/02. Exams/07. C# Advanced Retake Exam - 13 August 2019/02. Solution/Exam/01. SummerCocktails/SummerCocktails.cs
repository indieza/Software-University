using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._SummerCocktails
{
    public class SummerCocktails
    {
        private static void Main()
        {
            List<int> ingredientsValues = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> freshnessValues = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Dictionary<int, int> items = new Dictionary<int, int>
            {
                {150, 0 },
                {250, 0 },
                {300, 0 },
                {400, 0 }
            };

            while (ingredientsValues.Count != 0 && freshnessValues.Count != 0)
            {
                int ingredient = ingredientsValues.ElementAt(0);
                int freshness = freshnessValues.ElementAt(freshnessValues.Count - 1);

                int result = ingredient * freshness;

                if (ingredient == 0)
                {
                    ingredientsValues.RemoveAt(0);
                }
                else if (items.ContainsKey(result))
                {
                    items[result]++;
                    ingredientsValues.RemoveAt(0);
                    freshnessValues.RemoveAt(freshnessValues.Count - 1);
                }
                else
                {
                    ingredientsValues.RemoveAt(0);
                    ingredientsValues.Add(ingredient + 5);
                    freshnessValues.RemoveAt(freshnessValues.Count - 1);
                }
            }

            if (items.Values.All(v => v > 0))
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }

            if (ingredientsValues.Count != 0)
            {
                Console.WriteLine($"Ingredients left: {ingredientsValues.Sum()}");
            }

            if (items[250] > 0)
            {
                Console.WriteLine($" # Daiquiri --> {items[250]}");
            }
            if (items[150] > 0)
            {
                Console.WriteLine($" # Mimosa --> {items[150]}");
            }
            if (items[400] > 0)
            {
                Console.WriteLine($" # Mojito --> {items[400]}");
            }
            if (items[300] > 0)
            {
                Console.WriteLine($" # Sunshine --> {items[300]}");
            }
        }
    }
}