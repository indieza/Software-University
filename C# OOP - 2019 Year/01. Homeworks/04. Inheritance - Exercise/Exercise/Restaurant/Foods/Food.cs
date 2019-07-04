
namespace Restaurant.Foods
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Food : Product
    {
        private double grams;
        public Food(string name, decimal price, double grams)
            : base(name, price)
        {
            this.Grams = grams;
        }

        public double Grams
        {
            get => grams;
            set => grams = value;
        }
    }
}