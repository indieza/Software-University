using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MakeSalad
{
    public class MakeSalad
    {
        private static void Main()
        {
            Queue<string> vegetables = new Queue<string>(Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList());

            Stack<int> calories = new Stack<int>(Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            List<int> madeSalads = new List<int>();

            while (calories.Count != 0 && vegetables.Count != 0)
            {
                string currentVegetable = vegetables.Dequeue();
                int currentCalories = calories.Pop();
                int currentVegetableCalories = ExecuteVegetableCalories(currentVegetable);

                int leftCalories = currentCalories - currentVegetableCalories;

                while (leftCalories > 0 && vegetables.Count != 0)
                {
                    leftCalories -= ExecuteVegetableCalories(vegetables.Dequeue());
                }

                madeSalads.Add(currentCalories);
            }

            Console.WriteLine(string.Join(" ", madeSalads));

            if (calories.Count != 0)
            {
                Console.WriteLine(string.Join(" ", calories));
            }
            if (vegetables.Count != 0)
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
        }

        private static int ExecuteVegetableCalories(string currentVegetable)
        {
            int calories = 0;

            switch (currentVegetable)
            {
                case "tomato":
                    calories = 80;
                    break;

                case "carrot":
                    calories = 136;
                    break;

                case "lettuce":
                    calories = 109;
                    break;

                case "potato":
                    calories = 215;
                    break;

                default:
                    break;
            }

            return calories;
        }
    }
}