namespace _01.MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    internal class MatchFullName
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            while (line != "end")
            {
                Regex pattern = new Regex(@"\b[A-Z]{1}[a-z]{1,} [A-Z]{1}[a-z]{1,}\b");
                Match isMatched = pattern.Match(line);

                if (isMatched.Success)
                {
                    Console.WriteLine(line);
                }

                line = Console.ReadLine();
            }
        }
    }
}