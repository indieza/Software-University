using System;

public class Cat : Felime
{
    private string bread;

    public Cat(string animalName, double animalWeight, string animalType, string livingRegion, string bread)
        : base(animalName, animalWeight, animalType, livingRegion)
    {
        this.bread = bread;
    }

    private string Bread
    {
        get { return bread; }
        set { bread = value; }
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meowwww");
    }

    public override void Eat(Food food)
    {
        FoodEaten = food.Quantity;
    }

    public override string ToString()
    {
        return string.Format(
            $"{GetType().FullName}[{AnimalName}, {bread}, {AnimalWeight}, {LivingRegion}, {FoodEaten}]");
    }
}