namespace _09._IncreaseAgeStoredProcedure
{
    public static class Queries
    {
        public const string CreateProcedure = @"CREATE PROC usp_GetOlder @id INT
                                                AS
                                                UPDATE Minions
                                                   SET Age += 1
                                                 WHERE Id = @id";

        public const string SelectMinion = "SELECT Name, Age FROM Minions WHERE Id = @Id";
    }
}