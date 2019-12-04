namespace Cinema.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using ExportDto;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(m => m.Rating >= rating
                    && m.Projections.Any(p => p.Tickets.Any()))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections
                    .SelectMany(p => p.Tickets)
                    .Sum(t => t.Price))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = $"{m.Rating:F2}",
                    TotalIncomes = @$"{m.Projections
                        .SelectMany(p => p.Tickets)
                        .Sum(t => t.Price):F2}",
                    Customers = m.Projections
                        .SelectMany(p => p.Tickets)
                        .Select(t => t.Customer)
                        .Select(c => new
                        {
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Balance = $"{c.Balance:F2}"
                        })
                        .OrderByDescending(c => c.Balance)
                        .ThenBy(c => c.FirstName)
                        .ThenBy(c => c.LastName)
                })
                .Take(10)
                .ToArray();

            var moviesJson = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return moviesJson;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(c => c.Age >= age)
                .OrderByDescending(c => c.Tickets.Sum(t => t.Price))
                .Select(c => new ExportCustomerDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = $"{c.Tickets.Sum(t => t.Price):F2}",
                    SpentTime = TimeSpan
                        .FromSeconds(c.Tickets.Select(t => t.Projection).Sum(p => p.Movie.Duration.TotalSeconds))
                        .ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)
                })
                .Take(10)
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("Customers"));
            xmlSerializer.Serialize(writer, customers, ns);

            var customersXml = writer.GetStringBuilder();

            return customersXml.ToString().TrimEnd();
        }
    }
}