internal class Car
{
    public Car(
        string model,
        int speed,
        int power,
        int weight,
        string type,
        double pressure1,
        int age1,
        double pressure2,
        int age2,
        double pressure3,
        int age3,
        double pressure4,
        int age4)
    {
        this.Model = model;
        this.CarEngine = new Engine(speed, power);
        this.CarCargo = new Cargo(weight, type);
        this.Tires = new Tire[4];
        this.Tires[0] = new Tire(pressure1, age1);
        this.Tires[1] = new Tire(pressure2, age2);
        this.Tires[2] = new Tire(pressure3, age3);
        this.Tires[3] = new Tire(pressure4, age4);
    }

    public string Model { get; set; }

    public Engine CarEngine { get; set; }

    public Cargo CarCargo { get; set; }

    public Tire[] Tires { get; set; }

    public override string ToString()
    {
        return this.Model;
    }
}