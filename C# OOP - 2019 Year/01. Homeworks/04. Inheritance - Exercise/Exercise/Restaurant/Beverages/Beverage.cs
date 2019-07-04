namespace Restaurant.Beverages
{
    public class Beverage : Product
    {
        private double milliliters;

        public Beverage(string name, decimal price, double milliliters)
            : base(name, price)
        {
            this.Milliliters = milliliters;
        }

        public double Milliliters
        {
            get => this.milliliters;
            set => this.milliliters = value;
        }
    }
}