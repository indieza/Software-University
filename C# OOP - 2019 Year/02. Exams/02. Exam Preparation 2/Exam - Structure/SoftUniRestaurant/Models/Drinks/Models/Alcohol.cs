namespace ZooPark.Models.Drinks.Models
{
    public class Alcohol : Drink
    {
        private const decimal AloholPrice = 3.50m;

        public Alcohol(string name, int servingSize, string brand)
            : base(name, servingSize, AloholPrice, brand)
        {
        }
    }
}