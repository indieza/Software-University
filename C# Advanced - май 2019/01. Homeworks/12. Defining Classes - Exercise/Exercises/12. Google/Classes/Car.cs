namespace _12.Google.Classes
{
    public class Car
    {
        public Car(string carModel, double carSpeed)
        {
            this.CarModel = carModel;
            this.CarSpeed = carSpeed;
        }

        public string CarModel { get; set; }

        public double CarSpeed { get; set; }
    }
}
