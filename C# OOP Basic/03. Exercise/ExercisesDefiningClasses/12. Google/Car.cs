public class Car
{
    private string carModel;
    private long carSpeed;

    public Car(string carModel, long carSpeed)
    {
        this.carModel = carModel;
        this.carSpeed = carSpeed;
    }

    public string CarModel
    {
        get { return this.carModel; }
        set { this.carModel = value; }
    }

    public long CarSpeed
    {
        get { return this.carSpeed; }
        set { this.carSpeed = value; }
    }

    public override string ToString()
    {
        return $"{this.carModel} {this.carSpeed}";
    }
}