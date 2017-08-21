public class RPG : Ammunition
{
    public RPG(string name)
        : base(name, OutputMessages.RpgWeight, OutputMessages.RpgWeight * 100)
    {
    }
}