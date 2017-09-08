using System;

public class UltrasoftTyre : Tyre
{
    private const string UltrasoftName = "Ultrasoft";
    private double grip;
    private double degradation;

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
                throw new ArgumentException("Blown Tyre");
            }

            this.grip = value;
        }
    }

    public override double Degradation
    {
        get { return this.degradation; }

        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public override string Name => UltrasoftName;

    public override void DegradateTyre()
    {
        this.Degradation -= this.Grip + this.Hardness;
    }
}