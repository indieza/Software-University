public abstract class Ammunition : IAmmunition
{
    protected Ammunition(string name, double weight, double wearLevel)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = wearLevel;
    }

    public string Name { get; }

    public double Weight { get; }

    public double WearLevel { get; set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}