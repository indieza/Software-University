public class HardTyre : Tyre
{
    private const string HardTyreName = "Hard";

    public HardTyre(double hardness)
        : base(hardness)
    {
    }

    public override string Name => HardTyreName;

    public override void DegradateTyre()
    {
        this.Degradation -= this.Hardness;
    }
}