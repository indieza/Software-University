namespace _05.DateModifier
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            DateModifier twoDates = new DateModifier(
                DateTime.Parse(Console.ReadLine()), DateTime.Parse(Console.ReadLine()));

            int differenceInDays = twoDates.DateDifferenceInDays();

            Console.WriteLine(differenceInDays);
        }
    }
}