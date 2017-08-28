using System;
using System.Text;
using System.Text.RegularExpressions;

internal class CubicsMessages
{
    private const string pattern = @"^(\d+)([a-zA-Z]+)([^a-zA-Z]*)$";

    private static void Main()
    {
        string inputMessage;

        while ((inputMessage = Console.ReadLine()) != "Over!")
        {
            int messageLength = int.Parse(Console.ReadLine());
            Match match = Regex.Match(inputMessage, pattern);

            if (match.Success)
            {
                string prefix = match.Groups[1].Value;
                string message = match.Groups[2].Value;
                string end = string.Empty;

                if (match.Groups[3].Value != string.Empty)
                {
                    end = match.Groups[3].Value;
                }

                if (messageLength != message.Length)
                {
                    continue;
                }

                string indexes = Regex.Replace(prefix + end, @"\D*", string.Empty);

                StringBuilder sb = new StringBuilder();

                foreach (char index in indexes)
                {
                    int number = int.Parse(index.ToString());

                    if (number >= 0 && number < messageLength)
                    {
                        sb.Append(message[number]);
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }

                Console.WriteLine($"{message} == {sb}");
            }
        }
    }
}