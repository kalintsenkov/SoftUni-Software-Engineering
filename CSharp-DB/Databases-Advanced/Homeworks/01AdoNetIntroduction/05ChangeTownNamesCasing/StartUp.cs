namespace _05ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    using _01InitialSetup;

    public class StartUp
    {
        public static void Main()
        {
            var countryName = Console.ReadLine();

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                var rowsAffected = GetAffectedRows(connection, countryName);

                if (rowsAffected <= 0)
                {
                    Console.WriteLine("No town names were affected.");
                    Environment.Exit(0);
                }

                Console.WriteLine($"{rowsAffected} town names were affected.");
                
                var townNames = GetTownsByName(connection, countryName);

                Console.WriteLine($"[{string.Join(", ", townNames)}]");
            }
        }

        private static List<string> GetTownsByName(SqlConnection connection, string countryName)
        {
            var townNames = new List<string>();

            var namesQuery = @"SELECT t.Name 
                                 FROM Towns as t
                                 JOIN Countries AS c ON c.Id = t.CountryCode
                                WHERE c.Name = @countryName";

            using (var command = new SqlCommand(namesQuery, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string town = (string)dataReader[0];

                        townNames.Add(town);
                    }
                }
            }

            return townNames;
        }

        private static int GetAffectedRows(SqlConnection connection, string countryName)
        {
            var updateQuery = @"UPDATE Towns
                                   SET Name = UPPER(Name)
                                 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            using (var command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);

                return command.ExecuteNonQuery();
            }
        }
    }
}
