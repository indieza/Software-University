using _01._InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _04._AddMinion
{
    public class StartUp
    {
        public static int TownId;
        public static int MinionId;
        public static int VillainId;

        private static void Main()
        {
            List<string> minionsItems = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToList();

            string minionName = minionsItems[0];
            int minionAge = int.Parse(minionsItems[1]);
            string minionTown = minionsItems[2];

            List<string> villainsItems = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToList();

            string villainName = villainsItems[0];

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                ExecuteTownQuery(minionTown, connection);
                ExecuteMinionQuery(minionName, minionAge, connection);
                ExecuteVilainQuery(villainName, connection);
                ExecuteAddMinionToVillainQuery(minionName, villainName, connection);
            }
        }

        private static void ExecuteAddMinionToVillainQuery(string minionName, string villainName, SqlConnection connection)
        {
            using (SqlCommand insertMinionToVilainCommand = new SqlCommand(Queries.InsertMV, connection))
            {
                insertMinionToVilainCommand.Parameters.AddWithValue("@villainId", VillainId);
                insertMinionToVilainCommand.Parameters.AddWithValue("@minionId", MinionId);
                insertMinionToVilainCommand.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static void ExecuteVilainQuery(string villainName, SqlConnection connection)
        {
            using (SqlCommand checkVillainCommand = new SqlCommand(Queries.TakeVillainId, connection))
            {
                checkVillainCommand.Parameters.AddWithValue("@Name", villainName);

                object targetId = checkVillainCommand.ExecuteScalar();

                if (targetId != null)
                {
                    VillainId = (int)targetId;
                }
                else
                {
                    using (SqlCommand insertVillainCommand = new SqlCommand(Queries.InsertVillain, connection))
                    {
                        insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                        insertVillainCommand.ExecuteNonQuery();

                        Console.WriteLine($"Villain {villainName} was added to the database.");
                    }
                }
            }
        }

        private static void ExecuteMinionQuery(string minionName, int minionAge, SqlConnection connection)
        {
            using (SqlCommand checkMinionCommand = new SqlCommand(Queries.TakeMinionId, connection))
            {
                checkMinionCommand.Parameters.AddWithValue("@Name", minionName);

                object targetId = checkMinionCommand.ExecuteScalar();

                if (targetId != null)
                {
                    MinionId = (int)targetId;
                }
                else
                {
                    using (SqlCommand insertMinionCommand = new SqlCommand(Queries.InsertMinion, connection))
                    {
                        insertMinionCommand.Parameters.AddWithValue("@nam", minionName);
                        insertMinionCommand.Parameters.AddWithValue("@age", minionAge);
                        insertMinionCommand.Parameters.AddWithValue("@townId", TownId);

                        insertMinionCommand.ExecuteNonQuery();

                        Console.WriteLine($"Minion {minionName} was added to the database.");
                    }
                }
            }
        }

        private static void ExecuteTownQuery(string minionTown, SqlConnection connection)
        {
            using (SqlCommand checkTownCommand = new SqlCommand(Queries.TakeTownId, connection))
            {
                checkTownCommand.Parameters.AddWithValue("@townName", minionTown);

                object targetId = checkTownCommand.ExecuteScalar();

                if (targetId != null)
                {
                    TownId = (int)targetId;
                }
                else
                {
                    using (SqlCommand insertTownCommand = new SqlCommand(Queries.InsertTown, connection))
                    {
                        insertTownCommand.Parameters.AddWithValue("@townName", minionTown);
                        insertTownCommand.ExecuteNonQuery();

                        Console.WriteLine($"Town {minionTown} was added to the database.");
                    }
                }
            }
        }
    }
}