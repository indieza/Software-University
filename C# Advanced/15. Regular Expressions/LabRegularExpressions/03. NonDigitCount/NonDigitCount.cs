namespace _03.NonDigitCount
{
    using System;
    using System.Text.RegularExpressions;

    internal class NonDigitCount
    {
        private static void Main()
        {
            string text = Console.ReadLine();
            Regex pattern = new Regex(@"[^\d]");
            int count = pattern.Matches(text).Count;
            Console.WriteLine($"Non-digits: {count}");
        }
    }
}