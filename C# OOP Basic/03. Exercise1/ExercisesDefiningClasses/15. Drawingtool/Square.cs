public class Square : Figure
{
    private int n;

    public Square(int n)
    {
        this.n = n;
    }

    public int N
    {
        get { return this.n; }
        set { this.n = value; }
    }

    public override string ToString()
    {
        string result = string.Empty;

        result += "|" + new string('-', this.n) + "|" + "\n";

        for (int i = 0; i < this.n - 2; i++)
        {
            result += "|" + new string(' ', this.n) + "|" + "\n";
        }

        result += "|" + new string('-', this.n) + "|" + "\n";

        return result;
    }
}