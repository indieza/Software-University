namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Number");

            Assert.AreEqual("Make", car.Make);
            Assert.AreEqual("Number", car.RegistrationNumber);
        }

        [Test]
        public void Test_Parking_Constructure()
        {
            SoftPark softUniParking = new SoftPark();

            Assert.AreEqual(12, softUniParking.Parking.Count);
        }

        [Test]
        public void Test_Park_Car_Method_Does_Not_Contains_Park_Spot()
        {
            SoftPark softUniParking = new SoftPark();

            Assert.Throws<ArgumentException>(() => softUniParking.ParkCar("G3", this.car));
        }

        [Test]
        public void Test_Park_Car_Method_Park_Spot_Is_Taken()
        {
            SoftPark softUniParking = new SoftPark();
            softUniParking.ParkCar("A1", this.car);

            Assert.Throws<ArgumentException>(() => softUniParking.ParkCar("A1", this.car));
        }

        [Test]
        public void Test_Park_Car_Method_Car_Already_Exist()
        {
            SoftPark softUniParking = new SoftPark();
            softUniParking.ParkCar("A1", this.car);

            Assert.Throws<ArgumentException>(() => softUniParking.ParkCar("A1", this.car));
        }

        [Test]
        public void Test_Park_Car_Method()
        {
            SoftPark softUniParking = new SoftPark();

            Assert.AreEqual($"Car:{this.car.RegistrationNumber} parked successfully!",
                softUniParking.ParkCar("A1", this.car));
        }

        [Test]
        public void Test_Remove_Car_Method_Spot_Does_Not_Exist()
        {
            SoftPark softUniParking = new SoftPark();

            Assert.Throws<ArgumentException>(() => softUniParking.RemoveCar("G8", this.car));
        }

        [Test]
        public void Test_Remove_Car_Method_Car_Does_Not_Exist_For_That_Spot()
        {
            SoftPark softUniParking = new SoftPark();

            Assert.Throws<ArgumentException>(() => softUniParking.RemoveCar("A1", this.car));
        }

        [Test]
        public void Test_Remove_Car_Method()
        {
            SoftPark softUniParking = new SoftPark();
            softUniParking.ParkCar("A1", this.car);

            Assert.AreEqual($"Remove car:{this.car.RegistrationNumber} successfully!",
                softUniParking.RemoveCar("A1", this.car));
        }
    }
}