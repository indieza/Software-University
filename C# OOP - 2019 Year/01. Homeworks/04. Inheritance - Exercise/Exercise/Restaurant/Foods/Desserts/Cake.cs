
namespace Restaurant.Foods.Desserts
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Cake : Dessert
    {
        private const double CakeGrams = 250;
        private const double CakeCalories = 1000;
        private const decimal CakePrice = 5m;

        public Cake(string name)
            : base(name, CakePrice, CakeGrams, CakeCalories)
        {
        }
    }
}