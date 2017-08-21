public class Easy : Mission
{
    public Easy(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name
    {
        get { return OutputMessages.EasyMissionName; }
    }

    public override double EnduranceRequired
    {
        get { return OutputMessages.EasyEnduranceRequired; }
    }

    public override double WearLevelDecrement
    {
        get { return OutputMessages.EasyWearLevelDecrease; }
    }
}