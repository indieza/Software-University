namespace _04._AddMinion
{
    public static class Queries
    {
        public const string TakeTownId = "SELECT Id FROM Towns WHERE Name = @townName";

        public const string TakeMinionId = "SELECT Id FROM Minions WHERE Name = @Name";

        public const string TakeVillainId = "SELECT Id FROM Villains WHERE Name = @Name";

        public const string InsertTown = "INSERT INTO Towns (Name) VALUES (@townName)";

        public const string InsertMinion = "INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";

        public const string InsertVillain = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public const string InsertMV = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
    }
}