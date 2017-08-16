using System;

internal class Drawingtool
{
    private static void Main()
    {
        string type = Console.ReadLine();

        if (type == "Square")
        {
            Square square = new Square(int.Parse(Console.ReadLine()));
            Console.WriteLine(square.ToString());
        }
        else if (type == "Rectangle")
        {
            Rectangle rectangle = new Rectangle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine(rectangle.ToString());
        }
    }
}