
namespace Restaurant.Beverages.HotBeverage
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50m;
        private double caffeine;

        public Coffee(string name, double caffeine)
               : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine
        {
            get => this.caffeine;
            set => this.caffeine = value;
        }
    }
}