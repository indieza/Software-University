public abstract class Gem
{
    private readonly Clarity clarity;

    protected Gem(Clarity clarity, int strenght, int agility, int vitality)
    {
        this.clarity = clarity;
        this.Strength = strenght;
        this.Agility = agility;
        this.Vitality = vitality;
        this.SetClarity();
    }

    public int Strength { get; set; }

    public int Agility { get; set; }

    public int Vitality { get; set; }

    private void SetClarity()
    {
        var statClarity = (int)this.clarity;
        this.Strength += statClarity;
        this.Agility += statClarity;
        this.Vitality += statClarity;
    }
}