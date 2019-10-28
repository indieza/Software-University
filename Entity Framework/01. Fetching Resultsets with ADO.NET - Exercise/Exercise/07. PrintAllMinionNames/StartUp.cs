using _01._InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _07._PrintAllMinionNames
{
    public class StartUp
    {
        private static void Main()
        {
            List<string> names = new List<string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Queries.TakeAllMinionsNames, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        names.Add((string)reader[0]);
                    }
                }
            }

            Console.WriteLine($"Original Vision:\n{string.Join(Environment.NewLine, names)}");
            Console.WriteLine("New Vision:");

            while (names.Count != 0)
            {
                Console.WriteLine(names[0]);
                names.RemoveAt(0);

                if (names.Count == 0)
                {
                    break;
                }

                Console.WriteLine(names.Last());
                names.RemoveAt(names.Count - 1);
            }
        }
    }
}