using System;

public class Dough
{
    private string flourType;
    private string technique;
    private int weight;

    public Dough(string flourType, string technique, int weight)
    {
        this.FlourType = flourType;
        this.Technique = technique;
        this.Weight = weight;
    }

    private int Weight
    {
        get { return this.weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException($"Dough weight should be in the range [1..200].");
            }

            this.weight = value;
        }
    }

    private string Technique
    {
        get { return this.technique; }
        set
        {
            if ((value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade") || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Invalid type of dough.");
            }

            this.technique = value;
        }
    }

    private string FlourType
    {
        get { return this.flourType; }
        set
        {
            if ((value.ToLower() != "white" && value.ToLower() != "wholegrain") || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    public double CalculateCalories()
    {
        double baseCalories = 2;
        double modifier = 0;

        double result = baseCalories * this.weight;
        switch (this.flourType.ToLower())
        {
            case "white":
                modifier = 1.5;
                break;

            case "wholegrain":
                modifier = 1.0;
                break;
        }

        result *= modifier;

        switch (this.technique.ToLower())
        {
            case "crispy":
                modifier = 0.9;
                break;

            case "chewy":
                modifier = 1.1;
                break;

            case "homemade":
                modifier = 1.0;
                break;
        }

        result *= modifier;

        return result;
    }
}