namespace _04.ReplaceAtag
{
    using System;
    using System.Text.RegularExpressions;

    internal class ReplaceAtag
    {
        private static void Main()
        {
            string inputLine = Console.ReadLine();

            while (true)
            {
                if (inputLine == "end")
                {
                    break;
                }

                string result = Regex.Replace(inputLine, @"<a.*?href.*?=(.*?)>(.*?)<\/a>", @"[URL href=$1]$2[/URL]");

                Console.WriteLine(result);

                inputLine = Console.ReadLine();
            }
        }
    }
}