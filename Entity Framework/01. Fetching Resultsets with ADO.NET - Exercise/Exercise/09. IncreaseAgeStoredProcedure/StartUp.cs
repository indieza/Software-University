using _01._InitialSetup;
using System;
using System.Data;
using System.Data.SqlClient;

namespace _09._IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private static void Main()
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Queries.CreateProcedure, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand("usp_GetOlder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand(Queries.SelectMinion, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} – {age} years old");
                    }
                }
            }
        }
    }
}