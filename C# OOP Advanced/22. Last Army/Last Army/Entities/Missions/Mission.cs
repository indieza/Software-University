public abstract class Mission : IMission
{
    protected Mission(double scoreToComplete)
    {
        this.ScoreToComplete = scoreToComplete;
    }

    public abstract string Name { get; }

    public abstract double EnduranceRequired { get; }

    public double ScoreToComplete { get; }

    public abstract double WearLevelDecrement { get; }
}