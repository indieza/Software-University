namespace _05.ExtractTags
{
    using System;
    using System.Text.RegularExpressions;

    internal class ExtractTags
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                Regex pattern = new Regex(@"<.*?>");
                MatchCollection collection = pattern.Matches(line);

                foreach (Match item in collection)
                {
                    Console.WriteLine(item);
                }

                line = Console.ReadLine();
            }
        }
    }
}