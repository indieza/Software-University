using System;

public class Tiger : Felime
{
    public Tiger(string animalName, double animalWeight, string animalType, string livingRegion)
        : base(animalName, animalWeight, animalType, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("ROAAR!!!");
    }

    public override void Eat(Food food)
    {
        if (food.GetType().FullName.Equals("Meat"))
        {
            FoodEaten = food.Quantity;
        }
        else
        {
            throw new ArgumentException("Tigers are not eating that type of food!");
        }
    }
}