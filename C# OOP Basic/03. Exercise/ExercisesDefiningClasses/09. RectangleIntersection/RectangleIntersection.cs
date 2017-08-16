using System;
using System.Collections.Generic;
using System.Linq;

internal class RectangleIntersection
{
    private static void Main()
    {
        int[] items = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rectanglesCount = items[0];
        int intersectionCheck = items[1];

        List<Rectangle> rectangles = new List<Rectangle>();

        for (int i = 0; i < rectanglesCount; i++)
        {
            string[] rectanglesItems = Console.ReadLine().Split();
            string id = rectanglesItems[0];
            decimal width = decimal.Parse(rectanglesItems[1]);
            decimal height = decimal.Parse(rectanglesItems[2]);
            decimal topLeftHorizontal = decimal.Parse(rectanglesItems[3]);
            decimal topLeftVertical = decimal.Parse(rectanglesItems[4]);

            rectangles.Add(new Rectangle(id, width, height, topLeftHorizontal, topLeftVertical));
        }

        for (int i = 0; i < intersectionCheck; i++)
        {
            string[] ids = Console.ReadLine().Split();

            Rectangle firstRectangle = rectangles.First(rectagle => rectagle.Id == ids[0]);
            Rectangle secondRectangle = rectangles.First(rectagle => rectagle.Id == ids[1]);

            Console.WriteLine(firstRectangle.IsIntersect(secondRectangle).ToString().ToLower());
        }
    }
}