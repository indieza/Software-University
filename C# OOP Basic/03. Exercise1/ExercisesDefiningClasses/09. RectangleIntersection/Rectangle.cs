public class Rectangle
{
    private readonly decimal topLeftX;
    private readonly decimal topLeftY;
    private readonly decimal bottomRightY;
    private readonly decimal bottomRightX;
    private string id;
    private decimal width;
    private decimal height;

    public Rectangle(string id, decimal width, decimal height, decimal x, decimal y)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.topLeftX = x;
        this.topLeftY = y;
        this.bottomRightX = this.topLeftX + this.width;
        this.bottomRightY = this.topLeftY - this.height;
    }

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public bool IsIntersect(Rectangle rectangle)
    {
        if (this.topLeftX > rectangle.bottomRightX || rectangle.topLeftX > this.bottomRightX)
        {
            return false;
        }

        if (this.topLeftY < rectangle.bottomRightY || rectangle.topLeftY < this.bottomRightY)
        {
            return false;
        }

        return true;
    }
}