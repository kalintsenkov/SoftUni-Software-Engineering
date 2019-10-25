namespace _04AddMinion
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    using _01InitialSetup;

    public class StartUp
    {
        public static void Main()
        {
            var minionInfo = Console.ReadLine()
                .Split(new string[] { "Minion: ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var minionName = minionInfo[0];
            var minionAge = int.Parse(minionInfo[1]);
            var minionTown = minionInfo[2];

            var villainName = Console.ReadLine()
                .Split("Villain: ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray()[0];

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int? townId = GetTownIdByName(connection, minionTown);

                if (townId == null)
                {
                    Insert(connection, Queries.InsertTown, "@townName", minionTown);

                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                townId = GetTownIdByName(connection, minionTown);

                InsertMinion(connection, minionName, minionAge, townId);

                int? villainId = GetVillainIdByName(connection, villainName);

                if (villainId == null)
                {
                    Insert(connection, Queries.InsertVillain, "@villainName", villainName);

                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                villainId = GetVillainIdByName(connection, villainName);
                var minionId = GetMinionIdByName(connection, minionName);

                InsertMinionToVillain(connection, villainId, minionId);

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static int GetMinionIdByName(SqlConnection connection, string minionName)
        {
            using var command = new SqlCommand(Queries.MinionId, connection);

            command.Parameters.AddWithValue("@Name", minionName);

            return (int)command.ExecuteScalar();
        }

        private static int? GetVillainIdByName(SqlConnection connection, string villainName)
        {
            using var command = new SqlCommand(Queries.VillainId, connection);

            command.Parameters.AddWithValue("@Name", villainName);

            return (int?)command.ExecuteScalar();
        }

        private static int? GetTownIdByName(SqlConnection connection, string minionTown)
        {
            using var command = new SqlCommand(Queries.TownId, connection);

            command.Parameters.AddWithValue("@townName", minionTown);

            return (int?)command.ExecuteScalar();
        }

        private static void InsertMinionToVillain(SqlConnection connection, int? villainId, int minionId)
        {
            using var command = new SqlCommand(Queries.InsertMinionsVillains, connection);

            command.Parameters.AddWithValue("@villainId", villainId);
            command.Parameters.AddWithValue("@minionId", minionId);
            
            command.ExecuteNonQuery();
        }

        private static void InsertMinion(SqlConnection connection, string minionName, int minionAge, int? townId)
        {
            using var command = new SqlCommand(Queries.InsertMinion, connection);

            command.Parameters.AddWithValue("@name", minionName);
            command.Parameters.AddWithValue("@age", minionAge);
            command.Parameters.AddWithValue("@townId", townId);

            command.ExecuteNonQuery();
        }

        private static void Insert(SqlConnection connection, string query, string paramName, string paramValue)
        {
            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(paramName, paramValue);
            command.ExecuteNonQuery();
        }
    }
}
