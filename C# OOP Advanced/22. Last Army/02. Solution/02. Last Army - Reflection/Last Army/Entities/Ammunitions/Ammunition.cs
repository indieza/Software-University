public abstract class Ammunition : IAmmunition
{
    private const double WearLevelMultiply = 100;

    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = this.Weight * WearLevelMultiply;
    }

    public string Name { get; protected set; }

    public double Weight { get; protected set; }

    public double WearLevel { get; protected set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}