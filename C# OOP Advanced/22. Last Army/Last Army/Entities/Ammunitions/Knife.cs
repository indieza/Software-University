public class Knife : Ammunition
{
    public Knife(string name)
        : base(name, OutputMessages.KnifeWeight, OutputMessages.KnifeWeight * 100)
    {
    }
}