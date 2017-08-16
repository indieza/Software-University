public class Engine
{
    private readonly string model;
    private readonly int power;
    private readonly int? displacement;
    private readonly string efficiency;

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
        this.displacement = null;
        this.efficiency = null;
    }

    public Engine(string model, int power, int displacement)
        : this(model, power)
    {
        this.displacement = displacement;
    }

    public Engine(string model, int power, string efficiency)
        : this(model, power)
    {
        this.efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency)
        : this(model, power)
    {
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public string Model
    {
        get { return this.model; }
    }

    public override string ToString()
    {
        var result = string.Empty;
        var displacementValue = this.displacement == null ? "n/a" : this.displacement.ToString();
        var efficiencyValue = this.efficiency ?? "n/a";
        result += $"  {this.model}:\n";
        result += $"    Power: {this.power}\n";
        result += $"    Displacement: {displacementValue}\n";
        result += $"    Efficiency: {efficiencyValue}";
        return result;
    }
}