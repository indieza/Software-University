using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private IList<T> numbers;

    public Box()
    {
        this.Numbers = new List<T>();
    }

    public IList<T> Numbers
    {
        get { return this.numbers; }
        set { this.numbers = value; }
    }

    public int Count => this.numbers.Count;

    public void Add(T number)
    {
        this.numbers.Add(number);
    }

    public T Remove()
    {
        T lastNumber = this.numbers.LastOrDefault();
        this.numbers.RemoveAt(this.numbers.Count - 1);
        return lastNumber;
    }
}