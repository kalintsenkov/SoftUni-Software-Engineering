namespace _08IncreaseMinionAge
{
    public static class Queries
    {
        public const string UpdateMinionById 
            = @"UPDATE Minions
                   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                 WHERE Id = @Id";

        public const string SelectNameAndAge
            = @"SELECT Name, Age FROM Minions";
    }
}
