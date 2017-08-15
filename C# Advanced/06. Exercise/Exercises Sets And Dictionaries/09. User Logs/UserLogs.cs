namespace _09_User_Logs
{
    using System;
    using System.Collections.Generic;

    internal class UserLogs
    {
        private static void Main()
        {
            SortedDictionary<string, Dictionary<string, int>> userIPadresses =
                new SortedDictionary<string, Dictionary<string, int>>();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string ipAddress = data[0].Substring("IP=".Length, data[0].Length - "IP=".Length);
                string user = data[2].Substring("user=".Length, data[2].Length - "user=".Length);

                if (!userIPadresses.ContainsKey(user))
                {
                    userIPadresses[user] = new Dictionary<string, int>();
                }

                if (!userIPadresses[user].ContainsKey(ipAddress))
                {
                    userIPadresses[user][ipAddress] = 0;
                }

                userIPadresses[user][ipAddress]++;
            }

            foreach (var userPair in userIPadresses)
            {
                List<string> ipLogs = new List<string>();

                foreach (var ipPair in userPair.Value)
                {
                    ipLogs.Add(string.Join(" => ", ipPair.Key, ipPair.Value));
                }

                Console.WriteLine("{0}:\n{1}.", userPair.Key, string.Join(", ", ipLogs));
            }
        }
    }
}