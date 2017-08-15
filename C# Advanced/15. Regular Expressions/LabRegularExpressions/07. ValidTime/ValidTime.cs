namespace _07.ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    internal class ValidTime
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                Regex pattern = new Regex(@"^[01][0-9]:[0-5][0-9]:[0-5][0-9] AM|PM$");
                Match isMached = pattern.Match(line);

                Console.WriteLine(isMached.Success ? "valid" : "invalid");

                line = Console.ReadLine();
            }
        }
    }
}