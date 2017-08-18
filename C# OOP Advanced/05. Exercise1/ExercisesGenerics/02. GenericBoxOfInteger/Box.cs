public class Box<T>
{
    public Box(T element)
    {
        this.Element = element;
    }

    public T Element { get; set; }

    public override string ToString()
    {
        return $"{this.Element.GetType().FullName}: {this.Element}";
    }
}