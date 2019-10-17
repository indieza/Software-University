using _01._InitialSetup;
using System;
using System.Data.SqlClient;

namespace _03._MinionNames
{
    public class StartUp
    {
        public static void Main()
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Queries.VillainName, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    string villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine("No villain with ID 10 exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villainName}");
                }

                using (SqlCommand command = new SqlCommand(Queries.MinionNames, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                            return;
                        }

                        while (reader.Read())
                        {
                            long row = (long)reader[0];
                            string name = (string)reader[1];
                            int age = (int)reader[2];

                            Console.WriteLine($"{row}. {name} {age}");
                        }
                    }
                }
            }
        }
    }
}