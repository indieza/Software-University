using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough dough;
    private IList<Topping> toppings;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.Toppings = new List<Topping>();
    }

    public int ToppingsCount { get { return this.toppings.Count; } }

    public double TotalCalories { get { return this.CalculatePizzaCalories(); } }

    private IList<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            name = value;
        }
    }

    private double CalculatePizzaCalories()
    {
        double result = this.Dough.CalculateCalories() + this.toppings.Sum(x => x.CalculateCalories());

        return result;
    }

    public void AddTopping(Topping topping)
    {
        this.Toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.TotalCalories:F2} Calories.";
    }
}