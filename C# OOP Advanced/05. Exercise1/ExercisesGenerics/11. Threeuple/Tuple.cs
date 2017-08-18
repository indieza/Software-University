public class Tuple<T, V, U>
{
    private T item1;
    private V item2;
    private U item3;

    public Tuple(T item1, V item2, U item3)
    {
        this.Item1 = item1;
        this.Item2 = item2;
        this.Item3 = item3;
    }

    public T Item1
    {
        get { return item1; }
        set { item1 = value; }
    }

    public V Item2
    {
        get { return item2; }
        set { item2 = value; }
    }

    public U Item3
    {
        get { return item3; }
        set { item3 = value; }
    }

    public override string ToString()
    {
        return $"{Item1} -> {Item2} -> {Item3}";
    }
}