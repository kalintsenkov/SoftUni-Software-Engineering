namespace _03MinionNames
{
    using System;
    using System.Data.SqlClient;

    using _01InitialSetup;

    public class StartUp
    {
        public static void Main()
        {
            var id = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(Queries.VillainName, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    
                    var villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villainName}");
                }

                using (var command = new SqlCommand(Queries.MinionNames, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var dataReader = command.ExecuteReader())
                    {
                        if (!dataReader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                            return;
                        }

                        while (dataReader.Read())
                        {
                            var rowNum = (long)dataReader[0];
                            var name = (string)dataReader[1];
                            var age = (int)dataReader[2];

                            Console.WriteLine($"{rowNum}. {name} {age}");
                        }
                    }
                }
            }
        }
    }
}
