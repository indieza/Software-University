public abstract class Mammal : Animal
{
    private string livingRegion;

    protected Mammal(string animalName, double animalWeight, string animalType, string livingRegion)
        : base(animalName, animalWeight, animalType)
    {
        this.livingRegion = livingRegion;
    }

    protected string LivingRegion
    {
        get { return livingRegion; }
        set { livingRegion = value; }
    }

    public override string ToString()
    {
        return string.Format(
            $"{GetType().FullName}[{AnimalName}, {AnimalWeight}, {livingRegion}, {FoodEaten}]");
    }
}