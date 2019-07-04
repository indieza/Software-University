
namespace Restaurant.Beverages.ColdBeverage
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class ColdBeverage : Beverage
    {
        public ColdBeverage(string name, decimal price, double milliliters)
            : base(name, price, milliliters)
        {
        }
    }
}