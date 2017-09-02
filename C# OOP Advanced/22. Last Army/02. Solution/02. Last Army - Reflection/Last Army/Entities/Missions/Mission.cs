public abstract class Mission : IMission
{
    protected Mission(double scoreToComplete)
    {
        this.ScoreToComplete = scoreToComplete;
    }

    public double ScoreToComplete { get; }

    public abstract string Name { get; }

    public abstract double EnduranceRequired { get; }

    public abstract double WearLevelDecrement { get; }
}