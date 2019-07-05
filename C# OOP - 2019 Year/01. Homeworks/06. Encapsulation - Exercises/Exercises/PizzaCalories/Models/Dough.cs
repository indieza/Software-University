namespace PizzaCalories.Models
{
    using PizzaCalories.Constraints;
    using System;

    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(MessageExceptions.InvalidTypeOfDough);
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(MessageExceptions.InvalidTypeOfDough);
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;

            private set
            {
                if (value < LengthConstants.MinDoughWeight || value > LengthConstants.MaxDoughWeight)
                {
                    throw new ArgumentException(MessageExceptions.InvalidDoughWeight);
                }

                this.weight = value;
            }
        }

        public double TotalCalories()
        {
            double result = this.Weight * 2;

            result = ExecuteFlourType(result);
            result = ExecuteBakeType(result);

            return result;
        }

        private double ExecuteBakeType(double result)
        {
            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    result *= 0.9;
                    break;

                case "chewy":
                    result *= 1.1;
                    break;

                case "homemade":
                    result *= 1.0;
                    break;

                default:
                    break;
            }

            return result;
        }

        private double ExecuteFlourType(double result)
        {
            switch (this.FlourType.ToLower())
            {
                case "white":
                    result *= 1.5;
                    break;

                case "wholegrain":
                    result *= 1.0;
                    break;

                default:
                    break;
            }

            return result;
        }
    }
}