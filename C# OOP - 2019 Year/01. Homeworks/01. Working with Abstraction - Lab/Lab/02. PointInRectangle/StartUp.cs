using System;
using System.Collections.Generic;
using System.Linq;

namespace PointInRectangle
{
    public class StartUp
    {
        private static void Main()
        {
            List<double> cordinates = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            double topLeftX = cordinates[0];
            double topLeftY = cordinates[1];
            double bottomRightX = cordinates[2];
            double bottomRightY = cordinates[3];

            Rectangle rectangle =
                new Rectangle(new Point(topLeftX, topLeftY), new Point(bottomRightX, bottomRightY));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<double> pointsToCheck = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

                double pointX = pointsToCheck[0];
                double pointY = pointsToCheck[1];

                Point point = new Point(pointX, pointY);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}