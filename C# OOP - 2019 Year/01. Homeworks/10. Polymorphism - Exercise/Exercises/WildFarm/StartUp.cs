using System;
using System.Collections.Generic;
using WildFarm.Factories;
using WildFarm.Models.Animals;
using WildFarm.Models.Food;

namespace WildFarm
{
    public class StartUp
    {
        private static void Main()
        {
            List<Animal> animals = new List<Animal>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] animalsParams = line.Split();
                string[] foodParams = Console.ReadLine().Split();

                Animal animal = AnimalFactory.CreateAnimal(animalsParams);
                Food food = FoodFactory.CreateFood(foodParams);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);

                line = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}