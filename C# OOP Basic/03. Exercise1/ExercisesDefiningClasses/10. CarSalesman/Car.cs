public class Car
{
    private readonly string model;
    private readonly Engine engine;
    private readonly int? weight;
    private readonly string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = null;
        this.color = null;
    }

    public Car(string model, Engine engine, int weight)
        : this(model, engine)
    {
        this.weight = weight;
    }

    public Car(string model, Engine engine, string color)
        : this(model, engine)
    {
        this.color = color;
    }

    public Car(string model, Engine engine, int weight, string color)
        : this(model, engine)
    {
        this.weight = weight;
        this.color = color;
    }

    public override string ToString()
    {
        var result = string.Empty;
        var weightValue = this.weight == null ? "n/a" : this.weight.ToString();
        var colorValue = this.color ?? "n/a";
        result += $"{this.model}:\n";
        result += $"{this.engine}\n";
        result += $"  Weight: {weightValue}\n";
        result += $"  Color: {colorValue}";
        return result;
    }
}