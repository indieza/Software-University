public abstract class Animal
{
    private string animalName;
    private double animalWeight;
    private string animalType;
    private int foodEaten;

    protected Animal(string animalName, double animalWeight, string animalType)
    {
        this.animalName = animalName;
        this.animalWeight = animalWeight;
        this.animalType = animalType;
    }

    protected string AnimalName
    {
        get { return animalName; }
        set { animalName = value; }
    }

    protected string AnimalType
    {
        get { return animalType; }
        set { animalType = value; }
    }

    protected double AnimalWeight
    {
        get { return animalWeight; }
        set { animalWeight = value; }
    }

    protected int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public abstract void MakeSound();

    public abstract void Eat(Food food);
}