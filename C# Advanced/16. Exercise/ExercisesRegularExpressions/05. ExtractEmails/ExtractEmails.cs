namespace _05.ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    internal class ExtractEmails
    {
        private static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"(?<=\s|^)([A-Za-z0-9](\w|[.]|-)+[A-Za-z0-9]@[A-za-z](([A-Za-z]|-)+[.])+[A-Za-z]+)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[0]);
            }
        }
    }
}