using System;

public class Mouse : Mammal
{
    public Mouse(string animalName, double animalWeight, string animalType, string livingRegion)
        : base(animalName, animalWeight, animalType, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("SQUEEEAAAK!");
    }

    public override void Eat(Food food)
    {
        if (food.GetType().FullName.Equals("Vegetable"))
        {
            FoodEaten = food.Quantity;
        }
        else
        {
            throw new ArgumentException("Mouses are not eating that type of food!");
        }
    }
}