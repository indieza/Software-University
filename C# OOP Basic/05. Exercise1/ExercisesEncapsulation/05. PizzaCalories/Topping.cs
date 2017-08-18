using System;

public class Topping
{
    private string toppingType;
    private int weight;

    public Topping(string toppingType, int weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    private int Weight
    {
        get { return this.weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    private string ToppingType
    {
        get { return this.toppingType; }
        set
        {
            if ((value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce") || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.toppingType = value;
        }
    }

    public double CalculateCalories()
    {
        double baseCalories = 2;
        double modifier = 0;

        double result = baseCalories * this.weight;
        switch (this.toppingType.ToLower())
        {
            case "meat":
                modifier = 1.2;
                break;

            case "veggies":
                modifier = 0.8;
                break;

            case "cheese":
                modifier = 1.1;
                break;

            case "sauce":
                modifier = 0.9;
                break;
        }

        result *= modifier;

        return result;
    }
}