public class MachineGun : Ammunition
{
    public MachineGun(string name)
        : base(name, OutputMessages.MachineGunWeight, OutputMessages.MachineGunWeight * 100)
    {
    }
}