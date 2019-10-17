using _01._InitialSetup;
using System;
using System.Data.SqlClient;

namespace _02._VillainNames
{
    public class StartUp
    {
        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Queries.TopMinions, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int count = (int)reader[1];

                            Console.Write($"{name} - {count}");
                        }
                    }
                }
            }
        }
    }
}