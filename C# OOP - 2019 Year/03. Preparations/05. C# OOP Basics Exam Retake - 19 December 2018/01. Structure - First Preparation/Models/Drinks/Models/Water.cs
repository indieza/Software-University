namespace SoftUniRestaurant.Models.Drinks.Models
{
    public class Water : Drink
    {
        private const decimal WaterPrice = 1.50m;

        public Water(string name, int servingSize, string brand)
            : base(name, servingSize, WaterPrice, brand)
        {
        }
    }
}