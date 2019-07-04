
namespace Restaurant.Beverages.HotBeverage
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class HotBeverage : Beverage
    {
        public HotBeverage(string name, decimal price, double milliliters)
            : base(name, price, milliliters)
        {
        }
    }
}