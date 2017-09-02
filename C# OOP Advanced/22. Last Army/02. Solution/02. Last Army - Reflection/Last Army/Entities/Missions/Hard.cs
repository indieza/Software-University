public class Hard : Mission
{
    private const string HardName = "Disposal of terrorists";
    private const double Endurance = 80;
    private const double Decrement = 70;

    public Hard(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => HardName;

    public override double EnduranceRequired => Endurance;

    public override double WearLevelDecrement => Decrement;
}