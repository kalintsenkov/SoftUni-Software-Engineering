namespace _06RemoveVillain
{
    public static class Queries
    {
        public const string SelectVillainNameById
            = @"SELECT Name FROM Villains WHERE Id = @villainId";

        public const string DeleteFromMappingTable
            = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";

        public const string DeleteFromVillain
            = @"DELETE FROM Villains WHERE Id = @villainId";
    }
}
