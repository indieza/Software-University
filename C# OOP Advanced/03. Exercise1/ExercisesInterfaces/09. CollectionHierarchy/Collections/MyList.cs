using System.Collections.Generic;
using System.Linq;

public class MyList<T> : IMyList<T>
{
    private readonly List<T> data;
    public int Used { get; private set; }

    public MyList()
    {
        this.data = new List<T>();
        this.Used = 0;
    }

    public int Add(T element)
    {
        var index = 0;
        this.data.Insert(index, element);
        this.Used++;
        return index;
    }

    public T Remove()
    {
        var elementToRemove = this.data.FirstOrDefault();
        this.data.RemoveAt(0);
        this.Used--;
        return elementToRemove;
    }
}