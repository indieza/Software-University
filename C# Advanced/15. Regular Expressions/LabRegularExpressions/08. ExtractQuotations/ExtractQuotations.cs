namespace _08.ExtractQuotations
{
    using System;
    using System.Text.RegularExpressions;

    internal class ExtractQuotations
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            Regex pattern = new Regex("('|\")(.*?)\\1");
            MatchCollection collection = pattern.Matches(line);

            foreach (Match item in collection)
            {
                Console.WriteLine(item.Groups[2]);
            }
        }
    }
}