public class Box
{
    private decimal l;
    private decimal w;
    private decimal h;

    public Box(decimal l, decimal w, decimal h)
    {
        this.l = l;
        this.w = w;
        this.h = h;
    }

    public decimal L
    {
        get { return this.l; }
        set { this.l = value; }
    }

    public decimal W
    {
        get { return this.w; }
        set { this.w = value; }
    }

    public decimal H
    {
        get { return this.h; }
        set { this.h = value; }
    }

    public override string ToString()
    {
        string result = string.Empty;

        decimal surface = 2 * this.l * this.w + 2 * this.l * this.h + 2 * this.w * this.h;
        result += $"Surface Area - {surface:F2}\n";

        decimal lateral = 2 * this.l * this.h + 2 * this.w * this.h;
        result += $"Lateral Surface Area - {lateral:F2}\n";

        decimal volume = this.l * this.w * this.h;
        result += $"Volume - {volume:F2}";

        return result;
    }
}