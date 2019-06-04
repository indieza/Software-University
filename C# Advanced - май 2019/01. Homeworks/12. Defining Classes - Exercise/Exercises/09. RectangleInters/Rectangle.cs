namespace _09._Rectangle_Intersection
{
    public class Rectangle
    {
        public Rectangle(string id, Point points)
        {
            this.Id = id;
            this.Points = points;

        }

        public string Id { get; set; }

        public Point Points { get; set; }

        public bool IntersectRectangles(Rectangle secondRectangle)
        {
            return !(this.Points.TopRightX < secondRectangle.Points.TopLeftX ||
                   secondRectangle.Points.TopRightX < this.Points.TopLeftX ||
                   this.Points.BottomLeftY < secondRectangle.Points.TopLeftY ||
                   secondRectangle.Points.BottomRightY < this.Points.TopLeftY);

        }
    }
}
