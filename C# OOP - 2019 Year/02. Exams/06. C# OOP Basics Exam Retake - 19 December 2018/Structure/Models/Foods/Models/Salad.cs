namespace SoftUniRestaurant.Models.Foods.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Salad : Food
    {
        private const int InitialServingSize = 300;

        public Salad(string name, decimal price)
            : base(name, InitialServingSize, price)
        {
        }
    }
}