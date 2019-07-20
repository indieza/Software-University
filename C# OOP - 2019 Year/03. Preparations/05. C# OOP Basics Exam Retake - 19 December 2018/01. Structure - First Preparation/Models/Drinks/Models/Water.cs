namespace SoftUniRestaurant.Models.Drinks.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Water : Drink
    {
        private const decimal WaterPrice = 1.50m;

        public Water(string name, int servingSize, string brand)
            : base(name, servingSize, WaterPrice, brand)
        {
        }
    }
}