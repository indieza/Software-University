namespace SoftUniRestaurant.Models.Drinks.Models
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SoftUniRestaurant.Contracts;

    public abstract class Drink : IDrink
    {
        private string name;
        private int servingSize;
        private decimal price;
        private string brand;

        protected Drink(string name, int servingSize, decimal price, string brand)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
            this.Brand = brand;
        }

        public string Name

        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullDrinkName);
                }

                this.name = value;
            }
        }

        public int ServingSize
        {
            get => this.servingSize;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeDrinkServingSize);
                }

                this.servingSize = value;
            }
        }

        public decimal Price
        {
            get => this.price;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeDrinkPrice);
                }

                this.price = value;
            }
        }

        public string Brand
        {
            get => this.brand;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullDrinkBrand);
                }

                this.brand = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.ServingSize}ml - {this.Price:F2}lv";
        }
    }
}