using System.Collections.Generic;

public class AddCollection<T> : IAddCollection<T>
{
    private readonly List<T> data;

    public AddCollection()
    {
        this.data = new List<T>();
    }

    public int Add(T element)
    {
        var index = this.data.Count;
        this.data.Insert(index, element);
        return index;
    }
}