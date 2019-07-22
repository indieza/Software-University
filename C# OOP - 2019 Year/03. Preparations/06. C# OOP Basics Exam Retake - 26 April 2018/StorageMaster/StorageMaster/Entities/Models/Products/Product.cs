namespace StorageMaster.Entities.Models.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using StorageMaster.Entities.Interfaces;
    using StorageMaster.Contracts;

    public abstract class Product : IProduct
    {
        private double price;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get => this.price;

            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(ExceptionMessages.NegativeProductPrice);
                }

                this.price = value;
            }
        }

        public double Weight { get; private set; }
    }
}