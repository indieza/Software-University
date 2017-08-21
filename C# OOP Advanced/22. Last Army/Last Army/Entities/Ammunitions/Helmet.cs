public class Helmet : Ammunition
{
    public Helmet(string name)
        : base(name, OutputMessages.HelmetWeight, OutputMessages.HelmetWeight * 100)
    {
    }
}