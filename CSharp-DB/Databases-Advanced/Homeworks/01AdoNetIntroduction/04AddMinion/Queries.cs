namespace _04AddMinion
{
    public static class Queries
    {
        public const string TownId
            = "SELECT Id FROM Towns WHERE Name = @townName";

        public const string VillainId 
            = "SELECT Id FROM Villains WHERE Name = @Name";

        public const string MinionId
            = "SELECT Id FROM Minions WHERE Name = @Name";

        public const string InsertMinionsVillains 
            = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

        public const string InsertVillain
            = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public const string InsertMinion
            = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

        public const string InsertTown
            = "INSERT INTO Towns (Name) VALUES (@townName)";
    }
}
