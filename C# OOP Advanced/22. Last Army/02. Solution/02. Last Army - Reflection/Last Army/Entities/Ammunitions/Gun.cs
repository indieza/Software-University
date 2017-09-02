public class Gun : Ammunition
{
    public const double WeightGun = 1.4;

    public Gun(string name)
        : base(name, WeightGun)
    {
    }
}