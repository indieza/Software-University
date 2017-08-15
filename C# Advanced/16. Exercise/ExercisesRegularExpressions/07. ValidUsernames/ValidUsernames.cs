namespace _07.ValidUsernames
{
    using System;
    using System.Text.RegularExpressions;

    internal class ValidUsernames
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            string userName = @"(?<=[\s\/\\(\)]|^)([A-Za-z]\w{2,24})(?=[\s\/\\(\)]|$)";
            MatchCollection matches = Regex.Matches(input, userName);

            int biggestSum = 0;
            int pos = 0;

            for (int i = 0; i < matches.Count - 1; i++)
            {
                int currSum = matches[i].Length + matches[i + 1].Length;

                if (currSum > biggestSum)
                {
                    biggestSum = currSum;
                    pos = i;
                }
            }

            Console.WriteLine(matches[pos]);
            Console.WriteLine(matches[pos + 1]);
        }
    }
}