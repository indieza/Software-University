namespace SoftUniRestaurant.Models.Foods.Models
{
    using SoftUniRestaurant.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;

        protected Food(string name, int servingSize, decimal price)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullName);
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
                    throw new ArgumentException(ExceptionMessages.NegativeServingSize);
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
                    throw new ArgumentException(ExceptionMessages.NegativePrice);
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.ServingSize}g - {this.Price:F2}";
        }
    }
}