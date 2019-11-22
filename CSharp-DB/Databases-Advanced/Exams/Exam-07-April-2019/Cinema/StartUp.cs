namespace Cinema
{
    using System.IO;

    using Microsoft.EntityFrameworkCore;

    using Data;
    using DataProcessor;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var context = new CinemaContext();
        }

        private static void ResetDatabase(CinemaContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var inputMoviesJson = File.ReadAllText(@".\..\..\..\Datasets\movies.json");
            var moviesResult = Deserializer.ImportMovies(context, inputMoviesJson);

            var inputHallsJson = File.ReadAllText(@".\..\..\..\Datasets\halls-seats.json");
            var hallsResult = Deserializer.ImportHallSeats(context, inputHallsJson);

            var inputProjecionsXml = File.ReadAllText(@".\..\..\..\Datasets\projections.xml");
            var projectionsResult = Deserializer.ImportProjections(context, inputProjecionsXml);

            var inputCustomersXml = File.ReadAllText(@".\..\..\..\Datasets\customers-tickets.xml");
            var customersResult = Deserializer.ImportCustomerTickets(context, inputCustomersXml);
        }
    }
}