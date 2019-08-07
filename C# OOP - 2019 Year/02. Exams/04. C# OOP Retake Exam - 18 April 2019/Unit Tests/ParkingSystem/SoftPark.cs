using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ParkingSystem
{
    public class SoftPark
    {
        private readonly Dictionary<string, Car> parking;

        public SoftPark()
        {
            this.parking = new Dictionary<string, Car>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
        }

        public IReadOnlyDictionary<string, Car> Parking
            => this.parking.ToImmutableDictionary();

        public string ParkCar(string parkSpot, Car car)
        {
            if (!this.parking.ContainsKey(parkSpot))
            {
                throw new ArgumentException("Parking spot doesn't exists!");
            }

            if (this.parking[parkSpot] != null)
            {
                throw new ArgumentException("Parking spot is already taken!");
            }

            bool carExists = this.parking.Values
                .Any(x => x?.RegistrationNumber == car.RegistrationNumber);
            
            if (carExists)
            {
                throw new InvalidOperationException("Car is already parked!");
            }

            this.parking[parkSpot] = car;

            return $"Car:{car.RegistrationNumber} parked successfully!";
        }

        public string RemoveCar(string parkSpot, Car car)
        {
            if (!this.parking.ContainsKey(parkSpot))
            {
                throw new ArgumentException("Parking spot doesn't exists!");
            }

            if (this.parking[parkSpot] != car)
            {
                throw new ArgumentException($"Car for that spot doesn't exists!");
            }

            this.parking[parkSpot] = null;

            return $"Remove car:{car.RegistrationNumber} successfully!";
        }
    }
}
