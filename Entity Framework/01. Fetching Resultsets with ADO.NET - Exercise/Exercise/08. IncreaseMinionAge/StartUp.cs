using _01._InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _08._IncreaseMinionAge
{
    public class StartUp
    {
        private static void Main()
        {
            List<int> ids = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand updateMinion = new SqlCommand(Queries.UpdateMinionInformation, connection))
                {
                    foreach (int id in ids)
                    {
                        updateMinion.Parameters.AddWithValue("@Id", id);
                        updateMinion.ExecuteNonQuery();
                        updateMinion.Parameters.Clear();
                    }
                }

                using (SqlCommand command = new SqlCommand(Queries.SelectMinionInformation, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} {age}");
                    }
                }
            }
        }
    }
}