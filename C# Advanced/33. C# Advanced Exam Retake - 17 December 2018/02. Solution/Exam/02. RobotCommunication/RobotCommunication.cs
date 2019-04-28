using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.RobotCommunication
{
    public class RobotCommunication
    {
        private static string pattern = @"([_,])([a-zA-Z]+)([\d])";

        private static void Main()
        {
            string line = Console.ReadLine();

            while (line != "Report")
            {
                MatchCollection collection = Regex.Matches(line, pattern);
                List<string> text = new List<string>();

                foreach (Match item in collection)
                {
                    char specialChar = char.Parse(item.Groups[1].Value);
                    string letters = item.Groups[2].Value;
                    int number = int.Parse(item.Groups[3].Value);

                    text.Add(DecodeCode(specialChar, letters, number));
                }

                Console.WriteLine(string.Join(" ", text));

                line = Console.ReadLine();
            }
        }

        private static string DecodeCode(char specialChar, string letters, int number)
        {
            string result = string.Empty;

            if (specialChar == ',')
            {
                foreach (char item in letters)
                {
                    result += (char)(number + (int)item);
                }
            }
            else if (specialChar == '_')
            {
                foreach (char item in letters)
                {
                    result += (char)((int)item - number);
                }
            }

            return result;
        }
    }
}