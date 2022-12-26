namespace EnergyDrink
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static void Main()
        {
            const int milligramsForNight = 300;
            var drunkCaffeine = 0;

            var milligramsOfCaffeinе = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var energyDrinks = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (milligramsOfCaffeinе.Any() && energyDrinks.Any())
            {
                var milligrams = milligramsOfCaffeinе.Last();
                var drink = energyDrinks.First();
                var caffeine = milligrams * drink;

                if (drunkCaffeine + caffeine <= milligramsForNight)
                {
                    milligramsOfCaffeinе.RemoveAt(milligramsOfCaffeinе.Count - 1);
                    energyDrinks.RemoveAt(0);
                    drunkCaffeine += caffeine;
                }
                else
                {
                    milligramsOfCaffeinе.RemoveAt(milligramsOfCaffeinе.Count - 1);
                    energyDrinks.RemoveAt(0);
                    energyDrinks.Add(drink);
                    drunkCaffeine -= Math.Min(30, drunkCaffeine);
                }
            }

            if (energyDrinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {drunkCaffeine} mg caffeine.");
        }
    }
}