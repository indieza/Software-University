
namespace Restaurant.Foods.Starters
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Soup : Starter
    {
        public Soup(string name, decimal price, double grams)
            : base(name, price, grams)
        {
        }
    }
}