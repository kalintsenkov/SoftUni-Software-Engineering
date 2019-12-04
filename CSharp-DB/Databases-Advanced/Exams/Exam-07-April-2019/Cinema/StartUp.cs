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

            var moviesJson = File.ReadAllText(@".\..\..\..\Datasets\movies.json");
            var moviesResult = Deserializer.ImportMovies(context, moviesJson);

            var hallsSeatsJson = File.ReadAllText(@".\..\..\..\Datasets\halls-seats.json");
            var hallsSeatsResult = Deserializer.ImportHallSeats(context, hallsSeatsJson);

            var projectionsXml = File.ReadAllText(@".\..\..\..\Datasets\projections.xml");
            var projectionsResult = Deserializer.ImportProjections(context, projectionsXml);

            var customersTicketsXml = File.ReadAllText(@".\..\..\..\Datasets\customers-tickets.xml");
            var customersTicketsResult = Deserializer.ImportCustomerTickets(context, customersTicketsXml);
        }
    }
}