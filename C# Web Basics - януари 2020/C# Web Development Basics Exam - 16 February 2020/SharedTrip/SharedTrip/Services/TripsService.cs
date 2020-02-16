namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext dbContext;

        public TripsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(string startPoint, string endPoint, DateTime departureTime, int seats, string description, string imagePath)
        {
            var trip = new Trip
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = departureTime,
                Seats = seats,
                Description = description,
                ImagePath = imagePath
            };

            this.dbContext.Trips.Add(trip);
            dbContext.SaveChanges();
        }

        public IEnumerable<AllTripsViewModel> GetAll()
        {
            return this.dbContext.Trips.Select(t => new AllTripsViewModel
            {
                DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                EndPoint = t.EndPoint,
                Seats = t.Seats,
                StartPoint = t.StartPoint,
                Id = t.Id
            })
            .ToArray();
        }

        public GetTripViewModel GetTrip(string id)
        {
            return this.dbContext.Trips.Where(x => x.Id == id).Select(t => new GetTripViewModel
            {
                Id = t.Id,
                DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Description = t.Description,
                EndPoint = t.EndPoint,
                ImagePath = t.ImagePath,
                Seats = t.Seats,
                StartPoint = t.StartPoint
            })
            .FirstOrDefault();
        }

        public bool AddUserToTrip(string tripId, string userId)
        {
            var targetTrip = this.dbContext.Trips.FirstOrDefault(x => x.Id == tripId);
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            // Make mapping table validation
            if (!this.dbContext.UserTrips.Any(x => x.TripId == userTrip.TripId && x.UserId == userTrip.UserId))
            {
                targetTrip.UserTrips.Add(userTrip);
                dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}