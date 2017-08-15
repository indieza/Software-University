namespace _03.SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    internal class SeriesOfLetters
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"(.)\1+";
            Regex regex = new Regex(pattern);
            Console.WriteLine(regex.Replace(input, @"$1"));
        }
    }
}