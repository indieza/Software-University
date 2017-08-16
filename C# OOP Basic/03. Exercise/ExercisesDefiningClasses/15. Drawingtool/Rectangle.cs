public class Rectangle : Figure
{
    private int n;
    private int m;

    public Rectangle(int n, int m)
    {
        this.n = n;
        this.m = m;
    }

    public int N
    {
        get { return this.n; }
        set { this.n = value; }
    }

    public int M
    {
        get { return this.m; }
        set { this.m = value; }
    }

    public override string ToString()
    {
        string result = string.Empty;

        result += "|" + new string('-', this.n) + "|" + "\n";

        for (int i = 0; i < this.m - 2; i++)
        {
            result += "|" + new string(' ', this.n) + "|" + "\n";
        }

        result += "|" + new string('-', this.n) + "|" + "\n";

        return result;
    }
}