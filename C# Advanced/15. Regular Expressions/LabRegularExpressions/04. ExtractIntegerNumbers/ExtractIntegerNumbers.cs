namespace _04.ExtractIntegerNumbers
{
    using System;
    using System.Text.RegularExpressions;

    internal class ExtractIntegerNumbers
    {
        private static void Main()
        {
            string text = Console.ReadLine();

            Regex pattern = new Regex(@"\d+");
            MatchCollection collection = pattern.Matches(text);

            foreach (Match item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}