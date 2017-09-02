public class Easy : Mission
{
    private const string EasyName = "Suppression of civil rebellion";
    private const double Endurance = 20;
    private const double Decrement = 30;

    public Easy(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => EasyName;

    public override double EnduranceRequired => Endurance;

    public override double WearLevelDecrement => Decrement;
}