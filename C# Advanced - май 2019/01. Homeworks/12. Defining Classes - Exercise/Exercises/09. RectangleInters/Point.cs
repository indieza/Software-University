namespace _09._Rectangle_Intersection
{
    public class Point
    {
        public Point(double topLeftX, double topLeftY,double width,double height)
        {
            this.TopLeftX = topLeftX;
            this.TopLeftY = topLeftY;
            this.TopRightX = topLeftX+width;
            this.TopRightY = topLeftY;
            this.BottomLeftX = topLeftX;
            this.BottomLeftY = topLeftY+height;
            this.BottomRightX = topLeftX+width;
            this.BottomRightY = topLeftY+height;
        }

        public double TopLeftX { get; set; }
        public double TopLeftY { get; set; }
        public double TopRightX { get; set; }
        public double TopRightY { get; set; }
        public double BottomLeftX { get; set; }
        public double BottomLeftY { get; set; }
        public double BottomRightX { get; set; }
        public double BottomRightY { get; set; }
    }
}
