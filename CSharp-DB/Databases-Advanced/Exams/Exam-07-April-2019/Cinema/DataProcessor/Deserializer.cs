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
    using DataProcessor.ImportDto;

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

            var validMovies = new List<Movie>();
            var result = new StringBuilder();

            foreach (var dto in movieDtos)
            {
                var title = dto.Title;
                var isGenreValid = Enum.TryParse(dto.Genre, out Genre genre);
                var duration = TimeSpan.ParseExact(dto.Duration, "c", CultureInfo.InvariantCulture);
                var rating = dto.Rating;
                var director = dto.Director;

                var movie = new Movie
                {
                    Title = title,
                    Genre = genre,
                    Duration = duration,
                    Rating = rating,
                    Director = director
                };

                var isValid = IsValid(movie);
                var isTitleExist = context.Movies.Any(m => m.Title == title);

                if (!isValid || !isGenreValid || isTitleExist)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                validMovies.Add(movie);

                result.AppendLine(string.Format(
                    SuccessfulImportMovie,
                    movie.Title,
                    movie.Genre.ToString(),
                    $"{movie.Rating:F2}"));
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallDtos = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            var validHalls = new List<Hall>();
            var result = new StringBuilder();

            foreach (var dto in hallDtos)
            {
                var hall = new Hall
                {
                    Name = dto.Name,
                    Is4Dx = dto.Is4Dx,
                    Is3D = dto.Is3D
                };

                var isValid = IsValid(hall);

                if (!isValid || dto.Seats <= 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                for (int i = 1; i <= dto.Seats; i++)
                {
                    hall.Seats.Add(new Seat
                    {
                        Hall = hall
                    });
                }

                validHalls.Add(hall);

                var projectionType = GetProjectionType(hall.Is4Dx, hall.Is3D);

                result.AppendLine(string.Format(
                    SuccessfulImportHallSeat,
                    hall.Name,
                    projectionType,
                    hall.Seats.Count));
            }

            context.Halls.AddRange(validHalls);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            using var reader = new StringReader(xmlString);

            var serializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
            var projectionDtos = (ImportProjectionDto[])serializer.Deserialize(reader);

            var validProjections = new List<Projection>();
            var result = new StringBuilder();

            foreach (var dto in projectionDtos)
            {
                var movieId = dto.MovieId;
                var hallId = dto.HallId;
                var dateTime = DateTime.ParseExact(
                        dto.DateTime, @"yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                var isMovieValid = context.Movies.Any(m => m.Id == movieId);
                var isHallValid = context.Halls.Any(h => h.Id == hallId);

                if (!isMovieValid || !isHallValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = movieId,
                    HallId = hallId,
                    DateTime = dateTime
                };

                validProjections.Add(projection);

                var movie = context.Movies.Find(movieId);

                var projectionDateTime = projection
                    .DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                result.AppendLine(string.Format(
                    SuccessfulImportProjection,
                    movie.Title,
                    projectionDateTime));
            }

            context.Projections.AddRange(validProjections);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            using var reader = new StringReader(xmlString);

            var serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            var customerDtos = (ImportCustomerDto[])serializer.Deserialize(reader);

            var validCustomers = new List<Customer>();
            var result = new StringBuilder();

            foreach (var dto in customerDtos)
            {
                var customer = new Customer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Balance = dto.Balance
                };

                var isCustomerValid = IsValid(customer);

                var areTicketsValid = true;

                foreach (var ticketDto in dto.Tickets)
                {
                    var ticket = new Ticket
                    {
                        Customer = customer,
                        ProjectionId = ticketDto.ProjectionId,
                        Price = ticketDto.Price
                    };

                    var isProjectionValid = context.Projections
                        .Any(p => p.Id == ticket.ProjectionId);
                    var isTicketValid = IsValid(ticket);

                    if (!isProjectionValid || !isTicketValid)
                    {
                        areTicketsValid = false;
                        break;
                    }

                    customer.Tickets.Add(ticket);
                }

                if (!isCustomerValid || !areTicketsValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                validCustomers.Add(customer);

                result.AppendLine(string.Format(
                    SuccessfulImportCustomerTicket,
                    customer.FirstName,
                    customer.LastName,
                    customer.Tickets.Count));
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
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
            else if (is4Dx && is3D)
            {
                projectionType = "4Dx/3D";
            }
            else if (!is4Dx && !is3D)
            {
                projectionType = "Normal";
            }

            return projectionType;
        }
    }
}