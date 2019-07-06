using Cars.Interfaces;
using Cars.Models;
using System;

namespace Cars
{
    public class StartUp
    {
        private static void Main()
        {
            ICar seat = new Seat("Leon", "Grey");
            ICar tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat.ToString());
            Console.WriteLine(tesla.ToString());
        }
    }
}