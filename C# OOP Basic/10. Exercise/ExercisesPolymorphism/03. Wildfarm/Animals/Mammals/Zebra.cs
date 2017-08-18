using System;

public class Zebra : Mammal
{
    public Zebra(string animalName, double animalWeight, string animalType, string livingRegion)
        : base(animalName, animalWeight, animalType, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Zs");
    }

    public override void Eat(Food food)
    {
        if (food.GetType().FullName.Equals("Vegetable"))
        {
            FoodEaten = food.Quantity;
        }
        else
        {
            throw new ArgumentException("Zebras are not eating that type of food!");
        }
    }
}