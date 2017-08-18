namespace _02.Graphic_Editor
{
    using System;

    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            if (shape is Circle)
            {
                Console.WriteLine("I'm Circle");
            }
            else if (shape is Rectangle)
            {
                Console.WriteLine("I'm Rectangle");
            }
            else if (shape is Square)
            {
                Console.WriteLine("I'm Square");
            }
        }
    }
}