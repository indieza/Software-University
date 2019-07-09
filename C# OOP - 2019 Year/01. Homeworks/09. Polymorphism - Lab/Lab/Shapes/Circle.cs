namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            private set => this.radius = value;
        }

        public override double CalculateArea()
        {
            double result = Math.PI * this.Radius * this.Radius;

            return result;
        }

        public override double CalculatePerimeter()
        {
            double result = 2 * this.Radius * Math.PI;

            return result;
        }

        public override string Draw()
        {
            return base.Draw() + " Circle";
        }
    }
}