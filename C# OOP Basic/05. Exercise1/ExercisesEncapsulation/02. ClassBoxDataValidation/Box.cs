using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get { return this.length; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Length cannot be zero or negative. ");
            }

            this.length = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Width cannot be zero or negative. ");
            }

            this.width = value;
        }
    }

    public double Height
    {
        get { return this.height; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Height cannot be zero or negative. ");
            }

            this.height = value;
        }
    }

    public override string ToString()
    {
        string result = string.Empty;

        double surface = 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        result += $"Surface Area - {surface:F2}\n";

        double lateral = 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        result += $"Lateral Surface Area - {lateral:F2}\n";

        double volume = this.Length * this.Width * this.Height;
        result += $"Volume - {volume:F2}";

        return result;
    }
}