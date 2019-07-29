namespace SoftUniRestaurant.Models.Foods.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Soup : Food
    {
        private const int InitialServingSize = 245;

        public Soup(string name, decimal price)
            : base(name, InitialServingSize, price)
        {
        }
    }
}