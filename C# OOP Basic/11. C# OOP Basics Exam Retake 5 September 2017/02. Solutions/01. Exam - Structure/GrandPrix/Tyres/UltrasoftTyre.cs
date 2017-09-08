using System;

public class UltrasoftTyre : Tyre
{
    private const string UltrasoftName = "Ultrasoft";
    private double grip;

    public UltrasoftTyre(double hardness, double grip)
        : base(hardness)
    {
        this.Grip = grip;
    }

    public double Grip
    {
        get { return this.grip; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Grip value cannot be negative number");
            }

            this.grip = value;
        }
    }

    public override string Name => UltrasoftName;
}