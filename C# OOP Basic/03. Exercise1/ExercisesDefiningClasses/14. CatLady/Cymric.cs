public class Cymric : Cat
{
    private decimal furLength;

    public decimal FurLength
    {
        get { return this.furLength; }
        set { this.furLength = value; }
    }

    public override string ToString()
    {
        return $"Cymric {this.Name} {this.furLength:F2}";
    }
}