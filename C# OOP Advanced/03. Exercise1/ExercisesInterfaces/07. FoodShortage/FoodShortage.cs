using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FoodShortage
{
    internal class FoodShortage
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            IList<ICitizen> citizens = new List<ICitizen>();
            IList<IRebel> rebels = new List<IRebel>();

            for (int i = 0; i < n; i++)
            {
                string[] items = Console.ReadLine().Split();

                if (items.Length == 4)
                {
                    citizens.Add(new Citizen(items[0], int.Parse(items[1]), items[2], items[3]));
                }
                else
                {
                    rebels.Add(new Rebel(items[0], int.Parse(items[1]), items[2]));
                }
            }

            string name = Console.ReadLine();

            while (name != "End")
            {
                foreach (var citizen in citizens)
                {
                    if (citizen.Name.Equals(name))
                    {
                        citizen.BuyFood();
                    }
                }

                foreach (var rebel in rebels)
                {
                    if (rebel.Name.Equals(name))
                    {
                        rebel.BuyFood();
                    }
                }

                name = Console.ReadLine();
            }

            int result = 0;

            result += citizens.Sum(citizen => citizen.Food);
            result += rebels.Sum(rebel => rebel.Food);
            Console.WriteLine(result);
        }
    }
}