namespace Cinema.DataProcessor
{
    using AutoMapper;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
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
            var moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            List<Movie> movies = new List<Movie>();

            StringBuilder sb = new StringBuilder();

            foreach (var movieDto in moviesDto)
            {
                var movie = Mapper.Map<Movie>(movieDto);

                bool isValid = IsValid(movie);
                var isAdded = movies.Find(m => m.Title == movie.Title);

                if (isValid == false || isAdded != null)
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    movies.Add(movie);
                    sb.AppendLine(string.Format(SuccessfulImportMovie,
                        movie.Title,
                        movie.Genre.ToString(),
                        $"{movie.Rating:F2}"));
                }
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsSeatsDto = JsonConvert.DeserializeObject<ImportHallsSeatsDto[]>(jsonString);
            List<Hall> halls = new List<Hall>();

            StringBuilder sb = new StringBuilder();

            foreach (var hallSeatDto in hallsSeatsDto)
            {
                bool isValid = IsValid(hallSeatDto);

                if (isValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Hall hall = new Hall
                {
                    Name = hallSeatDto.Name,
                    Is4Dx = hallSeatDto.Is4Dx,
                    Is3D = hallSeatDto.Is3D
                };

                for (int i = 0; i < hallSeatDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                halls.Add(hall);

                string projectionType = string.Empty;

                if (hall.Is3D == true && hall.Is4Dx == true)
                {
                    projectionType = "4Dx/3D";
                }
                else if (hall.Is3D == true)
                {
                    projectionType = "3D";
                }
                else if (hall.Is4Dx == true)
                {
                    projectionType = "4Dx";
                }
                else
                {
                    projectionType = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat,
                    hall.Name,
                    projectionType,
                    hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer =
                new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
            var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Projection> projections = new List<Projection>();

            StringBuilder sb = new StringBuilder();

            foreach (var projectionDto in projectionsDto)
            {
                var targetHall = context.Halls.FirstOrDefault(h => h.Id == projectionDto.HallId);
                var targetMovie = context.Movies.FirstOrDefault(m => m.Id == projectionDto.MovieId);

                if (targetHall == null || targetMovie == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Projection projection = new Projection
                {
                    Movie = targetMovie,
                    MovieId = targetMovie.Id,
                    Hall = targetHall,
                    HallId = targetHall.Id,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime,
                    "yyyy-MM-dd HH:mm:ss",
                    CultureInfo.InvariantCulture)
                };

                projections.Add(projection);

                sb.AppendLine(string.Format(SuccessfulImportProjection,
                    projection.Movie.Title,
                    projection.DateTime.ToString("MM/dd/yyyy")));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Customer> customers = new List<Customer>();

            StringBuilder sb = new StringBuilder();

            foreach (var customerDto in customersDto)
            {
                var isValid = IsValid(customerDto);
                var isValidTickets = customerDto.Tickets.Any(t => IsValid(t));

                if (isValid == false || isValidTickets == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                foreach (var ticketDto in customerDto.Tickets)
                {
                    customer.Tickets.Add(new Ticket
                    {
                        Price = ticketDto.Price,
                        ProjectionId = ticketDto.ProjectionId
                    });
                }

                customers.Add(customer);

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket,
                    customer.FirstName,
                    customer.LastName,
                    customer.Tickets.Count));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}