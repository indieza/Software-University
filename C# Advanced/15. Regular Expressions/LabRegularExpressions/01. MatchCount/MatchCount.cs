namespace _01.MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    internal class MatchCount
    {
        private static void Main()
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            Regex regex = new Regex(pattern);
            int count = regex.Matches(text).Count;
            Console.WriteLine(count);
        }
    }
}