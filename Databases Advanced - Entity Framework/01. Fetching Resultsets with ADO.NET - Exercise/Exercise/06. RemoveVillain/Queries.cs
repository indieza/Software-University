namespace _06._RemoveVillain
{
    public static class Queries
    {
        public const string TakeVillainName = "SELECT Name FROM Villains WHERE Id = @villainId";

        public const string DeleteVillainMinions = @"DELETE
                                                       FROM MinionsVillains
                                                      WHERE VillainId = @villainId";

        public const string DeleteVillain = @"DELETE
                                                FROM Villains
                                            WHERE Id = @villainId";
    }
}