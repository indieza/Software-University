public class Siamese : Cat
{
    private decimal earSize;

    public decimal EarSize
    {
        get { return this.earSize; }
        set { this.earSize = value; }
    }

    public override string ToString()
    {
        return $"Siamese {this.Name} {this.earSize}";
    }
}