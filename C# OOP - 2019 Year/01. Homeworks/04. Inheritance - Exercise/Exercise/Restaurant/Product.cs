namespace Restaurant
{
    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public decimal Price
        {
            get => this.price;
            set => this.price = value;
        }
    }
}