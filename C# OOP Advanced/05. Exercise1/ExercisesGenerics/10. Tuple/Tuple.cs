public class Tuple<T, V>
{
    private T item1;
    private V item2;

    public Tuple(T item1, V item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
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

    public override string ToString()
    {
        return $"{Item1} -> {Item2}";
    }
}