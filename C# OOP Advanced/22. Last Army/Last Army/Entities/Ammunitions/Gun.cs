public class Gun : Ammunition
{
    public Gun(string name)
        : base(name, OutputMessages.GunWeight, OutputMessages.GunWeight * 100)
    {
    }
}