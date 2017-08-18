public class Car
{
    private string carModel;
    private decimal fuelAmount;
    private decimal fuelConsumationFor1km;
    private decimal distanceTraveled;

    public Car(string carModel, decimal fuelAmount, decimal fuelConsumationFor1Km)
    {
        this.carModel = carModel;
        this.fuelAmount = fuelAmount;
        this.fuelConsumationFor1km = fuelConsumationFor1Km;
        this.distanceTraveled = 0;
    }

    public string CarModel
    {
        get { return this.carModel; }
        set { this.carModel = value; }
    }

    public decimal FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public decimal FuelConsumationFor1km
    {
        get { return this.fuelConsumationFor1km; }
        set { this.fuelConsumationFor1km = value; }
    }

    public bool CanTakeTheDistance(decimal distance)
    {
        decimal allConsuming = this.fuelConsumationFor1km * distance;

        if (allConsuming <= this.fuelAmount)
        {
            this.fuelAmount -= allConsuming;
            this.distanceTraveled += distance;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{this.carModel} {this.fuelAmount:F2} {this.distanceTraveled}";
    }
}