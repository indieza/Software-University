namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Collections.Generic;

    public interface ITripsService
    {
        void Add(string startPoint, string endPoint, DateTime departureTime, int seats, string description, string imagePath);

        IEnumerable<AllTripsViewModel> GetAll();

        GetTripViewModel GetTrip(string id);

        bool AddUserToTrip(string tripId, string userId);
    }
}