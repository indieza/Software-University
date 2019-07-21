namespace SoftUniRestaurant.Models.Drinks.Models
{
    public class Juice : Drink
    {
        private const decimal JuicePrice = 1.80m;

        public Juice(string name, int servingSize, string brand)
            : base(name, servingSize, JuicePrice, brand)
        {
        }
    }
}