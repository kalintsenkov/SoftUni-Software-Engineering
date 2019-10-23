namespace _02VillainNames
{
    using System;
    using System.Data.SqlClient;

    using _01InitialSetup;

    public class StartUp
    {
        public static void Main()
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                var selectQuery = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount " +
                    "FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                    "GROUP BY v.Id, v.Name " +
                    "HAVING COUNT(mv.VillainId) > 3" +
                    "ORDER BY COUNT(mv.VillainId)";

                using (var command = new SqlCommand(selectQuery, connection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine($"{dataReader[0]} - {dataReader[1]}");
                        }
                    }
                }
            }
        }
    }
}
