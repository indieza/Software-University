namespace _07_Fix_Emails
{
    using System;
    using System.Collections.Generic;

    internal class FixEmails
    {
        private static void Main()
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();
            Dictionary<string, string> modifiedEmails = new Dictionary<string, string>();

            string input;

            while ((input = Console.ReadLine()) != "stop")
            {
                emails[input] = Console.ReadLine();
            }

            foreach (var pair in emails)
            {
                if (!pair.Value.EndsWith("uk") && !pair.Value.EndsWith("us"))
                {
                    modifiedEmails[pair.Key] = pair.Value;
                }
            }

            foreach (var pair in modifiedEmails)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}