public class AutomaticMachine : Ammunition
{
    public AutomaticMachine(string name)
        : base(name, OutputMessages.AutomaticMachineWeight, OutputMessages.AutomaticMachineWeight * 100)
    {
    }
}