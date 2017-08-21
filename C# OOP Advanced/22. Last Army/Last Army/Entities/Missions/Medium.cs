public class Medium : Mission
{
    public Medium(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name
    {
        get { return OutputMessages.MediumMissionName; }
    }

    public override double EnduranceRequired
    {
        get { return OutputMessages.MediumEnduranceRequired; }
    }

    public override double WearLevelDecrement
    {
        get { return OutputMessages.MediumWearLevelDecrease; }
    }
}