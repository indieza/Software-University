public class Hard : Mission
{
    private const string HardMissionName = "Disposal of terrorists";
    private const double HardEnduranceRequired = 80;
    private const double HardWearLevelDecrement = 70;

    public Hard(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => HardMissionName;

    public override double EnduranceRequired => HardEnduranceRequired;

    public override double WearLevelDecrement => HardWearLevelDecrement;
}