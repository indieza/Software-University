public class Medium : Mission
{
    private const string MediumName = "Capturing dangerous criminals";
    private const double Endurance = 50;
    private const double Decrement = 50;

    public Medium(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => MediumName;

    public override double EnduranceRequired => Endurance;

    public override double WearLevelDecrement => Decrement;
}