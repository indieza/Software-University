namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get => this.height;
            private set => this.height = value;
        }

        public double Width
        {
            get => this.width;
            private set => this.width = value;
        }

        public override double CalculateArea()
        {
            double result = this.Height * this.Width;

            return result;
        }

        public override double CalculatePerimeter()
        {
            double result = 2 * (this.Height + this.Width);

            return result;
        }

        public override string Draw()
        {
            return base.Draw() + " Rectangle";
        }
    }
}