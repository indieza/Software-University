namespace _06.ValidUsernames
{
    using System;
    using System.Text.RegularExpressions;

    internal class ValidUsernames
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                Regex pattern = new Regex(@"^[\w\d-_]{3,16}$");
                Match isMached = pattern.Match(line);

                Console.WriteLine(isMached.Success ? "valid" : "invalid");

                line = Console.ReadLine();
            }
        }
    }
}