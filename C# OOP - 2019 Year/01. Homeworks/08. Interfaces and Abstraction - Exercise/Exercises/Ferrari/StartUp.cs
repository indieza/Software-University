using System;

namespace Ferrari
{
    public class StartUp
    {
        private static void Main()
        {
            string driver = Console.ReadLine();
            ICar car = new Ferrari(driver);
            Console.WriteLine(car.ToString());
        }
    }
}