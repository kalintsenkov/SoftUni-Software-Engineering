namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage
            = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movieDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            var movies = new List<Movie>();
            var sb = new StringBuilder();

            foreach (var movieDto in movieDtos)
            {
                var isMovieValid = IsValid(movieDto);
                var isGenreValid = Enum.TryParse(movieDto.Genre, out Genre genre);
                var isTitleExists = movies.Any(m => m.Title == movieDto.Title);

                if (!isMovieValid || !isGenreValid || isTitleExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Duration = TimeSpan.ParseExact(movieDto.Duration, "c", CultureInfo.InvariantCulture),
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                movies.Add(movie);

                sb.AppendLine(string.Format(
                    SuccessfulImportMovie,
                    movie.Title,
                    movie.Genre.ToString(),
                    $"{movie.Rating:F2}"));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallDtos = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            var halls = new List<Hall>();
            var sb = new StringBuilder();

            foreach (var hallDto in hallDtos)
            {
                if (!IsValid(hallDto) || hallDto.Seats <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D
                };

                for (int seat = 1; seat <= hallDto.Seats; seat++)
                {
                    hall.Seats.Add(new Seat { Hall = hall });
                }

                halls.Add(hall);

                var hallProjectionType = GetProjectionType(hall.Is4Dx, hall.Is3D);

                sb.AppendLine(string.Format(
                    SuccessfulImportHallSeat,
                    hall.Name,
                    hallProjectionType,
                    hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            using var reader = new StringReader(xmlString);

            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
            var projectionDtos = (ImportProjectionDto[])xmlSerializer.Deserialize(reader);

            var projections = new List<Projection>();
            var sb = new StringBuilder();

            foreach (var projectionDto in projectionDtos)
            {
                var isMovieIdExisting = context.Movies.Any(m => m.Id == projectionDto.MovieId);
                var isHallIdExisting = context.Halls.Any(h => h.Id == projectionDto.HallId);

                if (!isMovieIdExisting || !isHallIdExisting)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = projectionDto.MovieId,
                    HallId = projectionDto.HallId,
                    DateTime = DateTime
                        .ParseExact(projectionDto.DateTime, @"yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);

                var projectionTitle = context.Movies
                    .Find(projectionDto.MovieId)
                    .Title;
                var dateTime = projection.DateTime
                    .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                sb.AppendLine(string.Format(
                    SuccessfulImportProjection,
                    projectionTitle,
                    dateTime));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            using var reader = new StringReader(xmlString);

            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            var customerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);

            var customers = new List<Customer>();
            var sb = new StringBuilder();

            foreach (var customerDto in customerDtos)
            {
                if (!IsValid(customerDto) || customerDto.Tickets.Any(t => !IsValid(t)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance,
                    Tickets = customerDto.Tickets
                        .Select(t => new Ticket
                        {
                            ProjectionId = t.ProjectionId,
                            Price = t.Price
                        })
                        .ToArray()
                };

                customers.Add(customer);

                sb.AppendLine(string.Format(
                    SuccessfulImportCustomerTicket,
                    customer.FirstName,
                    customer.LastName,
                    customer.Tickets.Count));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static string GetProjectionType(bool is4Dx, bool is3D)
        {
            var projectionType = string.Empty;

            if (is4Dx && !is3D)
            {
                projectionType = "4Dx";
            }
            else if (!is4Dx && is3D)
            {
                projectionType = "3D";
            }
            else if (is4Dx && is4Dx)
            {
                projectionType = "4Dx/3D";
            }
            else if (!is4Dx && !is3D)
            {
                projectionType = "Normal";
            }

            return projectionType;
        }

        private static bool IsValid(object instance)
        {
            var validationContext = new ValidationContext(instance);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(instance, validationContext, validationResults, true);

            return isValid;
        }
    }
}