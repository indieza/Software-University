namespace SoftUniRestaurant.Models.Drinks.Models
{
    public class Alcohol : Drink
    {
        private const decimal InitialPrice = 3.50m;

        public Alcohol(string name, int servingSize, string brand)
            : base(name, servingSize, InitialPrice, brand)
        {
        }
    }
}