namespace PizzaCalories.Models
{
    using PizzaCalories.Constraints;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrWhiteSpace(value) ||
                    value.Length > LengthConstants.PizzaNameMaxLength)
                {
                    throw new ArgumentException(MessageExceptions.InvalidPizzaNameLength);
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;
            private set => this.dough = value;
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == LengthConstants.MaxToppingsCount)
            {
                throw new ArgumentException(MessageExceptions.InvalidToppingsCount);
            }
            else
            {
                this.toppings.Add(topping);
            }
        }

        public override string ToString()
        {
            double totalCalories = this.Dough.TotalCalories() + this.toppings.Sum(t => t.TotalCalories());
            return $"{this.Name} - {totalCalories:F2} Calories.";
        }
    }
}