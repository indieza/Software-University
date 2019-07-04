
namespace Restaurant.Foods.MainDishes
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class MainDish : Food
    {
        public MainDish(string name, decimal price, double grams) 
            : base(name, price, grams)
        {
        }
    }
}