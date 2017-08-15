namespace _01_Unique_Usernames
{
    using System;
    using System.Collections.Generic;

    internal class UniqueUsernames
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> uniqueUsernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                uniqueUsernames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\n", uniqueUsernames));
        }
    }
}