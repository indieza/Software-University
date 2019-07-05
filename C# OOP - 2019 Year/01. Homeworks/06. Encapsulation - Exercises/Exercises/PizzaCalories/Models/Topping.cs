namespace PizzaCalories.Models
{
    using PizzaCalories.Constraints;
    using System;

    public class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;

            private set
            {
                if (value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException(string.Format(MessageExceptions.InvalidToppingType, value));
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;

            private set
            {
                if (value < LengthConstants.MinToppingWeight || value > LengthConstants.MaxToppingWeight)
                {
                    throw new ArgumentException(string.Format(MessageExceptions.IncalidToppingWeight, this.Type));
                }

                this.weight = value;
            }
        }

        public double TotalCalories()
        {
            double result = 2 * this.Weight;

            result = ExecuteToppingType(result);

            return result;
        }

        private double ExecuteToppingType(double result)
        {
            switch (this.Type.ToLower())
            {
                case "meat":
                    result *= 1.2;
                    break;

                case "veggies":
                    result *= 0.8;
                    break;

                case "cheese":
                    result *= 1.1;
                    break;

                case "sauce":
                    result *= 0.9;
                    break;

                default:
                    break;
            }

            return result;
        }
    }
}