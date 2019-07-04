namespace Restaurant.Foods
{
    public class Food : Product
    {
        private double grams;

        public Food(string name, decimal price, double grams)
            : base(name, price)
        {
            this.Grams = grams;
        }

        public double Grams
        {
            get => grams;
            set => grams = value;
        }
    }
}