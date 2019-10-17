using System.Data.SqlClient;

namespace _01._InitialSetup
{
    public class StartUp
    {
        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Configuration.CreateDB, connection))
                {
                    command.ExecuteNonQuery();
                }

                foreach (var statement in Configuration.TableCommnadStatments)
                {
                    using (SqlCommand command = new SqlCommand(statement, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                foreach (var statement in Configuration.InsertStatments)
                {
                    using (SqlCommand command = new SqlCommand(statement, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}