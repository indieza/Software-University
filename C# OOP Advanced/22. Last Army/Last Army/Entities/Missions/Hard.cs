public class Hard : Mission
{
    public Hard(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name
    {
        get { return OutputMessages.HardMissionName; }
    }

    public override double EnduranceRequired
    {
        get { return OutputMessages.HardEnduranceRequired; }
    }

    public override double WearLevelDecrement
    {
        get { return OutputMessages.HardWearLevelDecrease; }
    }
}