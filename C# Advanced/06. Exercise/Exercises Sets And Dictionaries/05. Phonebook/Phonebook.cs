namespace _05_Phonebook
{
    using System;
    using System.Collections.Generic;

    internal class Phonebook
    {
        private static void Main()
        {
            string input;

            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while ((input = Console.ReadLine()) != "search")
            {
                string[] data = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                string phonenumber = data[1];
                phonebook[name] = phonenumber;
            }

            while ((input = Console.ReadLine()) != "stop")
            {
                string name = input;

                if (phonebook.ContainsKey(name))
                {
                    Console.WriteLine("{0} -> {1}", name, phonebook[name]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", name);
                }
            }
        }
    }
}