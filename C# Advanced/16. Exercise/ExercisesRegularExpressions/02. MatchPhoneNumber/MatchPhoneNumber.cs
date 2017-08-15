namespace _02.MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    internal class MatchPhoneNumber
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            while (line != "end")
            {
                Regex pattern = new Regex(@"[+][3][5][9]( |-)[2]\1\d{3}\1\d{4}\b");
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