namespace _09._Rectangle_Intersection
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string id = line[0];
                double width = double.Parse(line[1]);
                double height = double.Parse(line[2]);
                double topLeftX = double.Parse(line[3]);
                double topLeftY = double.Parse(line[4]);
                Point points = new Point(topLeftX, topLeftY, width, height);
                Rectangle rectangle = new Rectangle(id, points);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < m; i++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstRectangleId = line[0];
                string secondRectangleId = line[1];
                int firstRectangleIndex = rectangles.FindIndex(x => x.Id == firstRectangleId);
                int secondRectangleIndex = rectangles.FindIndex(x => x.Id == secondRectangleId);

                Console.WriteLine(
                    rectangles[firstRectangleIndex].IntersectRectangles(rectangles[secondRectangleIndex])
                    ? "true"
                    : "false");
            }
        }
    }
}