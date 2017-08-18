using System;
using System.Collections.Generic;
using System.Linq;

public class WildfarmMain
{
    public static Animal Animal;

    public static void Main()
    {
        var animalInfo = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        while (!animalInfo[0].Equals("End"))
        {
            var food = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var animalType = animalInfo[0];
            var animalName = animalInfo[1];
            var animalWeight = double.Parse(animalInfo[2]);
            var animalLivingRegion = animalInfo[3];

            var curentFood = GetCurrentFood(food);

            try
            {
                if (animalInfo.Count > 4)
                {
                    var catBreed = animalInfo[4];
                    Animal = new Cat(animalName, animalWeight, animalType, animalLivingRegion, catBreed);
                    Animal.MakeSound();
                    Animal.Eat(curentFood);
                    Console.WriteLine(Animal.ToString());
                }
                else
                {
                    Animal = GetCurrentAnimal(animalType, animalName, animalWeight, animalLivingRegion);
                    Animal.MakeSound();
                    Animal.Eat(curentFood);
                    Console.WriteLine(Animal.ToString());
                }
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
                Console.WriteLine(Animal.ToString());
            }

            animalInfo = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }

    private static Animal GetCurrentAnimal(string animalType, string animalName, double animalWeight, string animalLivingRegion)
    {
        switch (animalType)
        {
            case "Tiger":
                return new Tiger(animalName, animalWeight, animalType, animalLivingRegion);

            case "Mouse":
                return new Mouse(animalName, animalWeight, animalType, animalLivingRegion);

            case "Zebra":
                return new Zebra(animalName, animalWeight, animalType, animalLivingRegion);

            default:
                return new Mouse(animalName, animalWeight, animalType, animalLivingRegion);
        }
    }

    private static Food GetCurrentFood(List<string> food)
    {
        if (food[0].Equals("Vegetable"))
        {
            return new Vegetable(int.Parse(food[1]));
        }

        return new Meat(int.Parse(food[1]));
    }
}