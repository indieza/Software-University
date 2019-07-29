namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark parking;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Make", "Number");
            this.parking = new SoftPark();
        }

        [Test]
        public void Test_Car_Constructure()
        {
            Assert.AreEqual("Make", this.car.Make);
            Assert.AreEqual("Number", this.car.RegistrationNumber);
        }

        [Test]
        public void Test_Park_Constructure()
        {
            Assert.AreEqual(12, this.parking.Parking.Count);
        }

        [Test]
        public void Test_Add_Car_Spot_Does_Not_Exist()
        {
            Assert.Throws<ArgumentException>(() => this.parking.ParkCar("G3", this.car));
        }

        [Test]
        public void Test_Add_Car_Spot_Taken()
        {
            this.parking.ParkCar("A1", this.car);
            Car newCar = new Car("Make1", "Number1");
            Assert.Throws<ArgumentException>(() => this.parking.ParkCar("A1", this.car));
        }

        [Test]
        public void Test_Add_Car_Car_Exist()
        {
            this.parking.ParkCar("A1", this.car);

            Assert
                .Throws<InvalidOperationException>
                (() => this.parking.ParkCar("A2", this.car));
        }

        [Test]
        public void Test_Park_Car()
        {
            Assert
                .AreEqual
                ($"Car:{this.car.RegistrationNumber} parked successfully!",
                this.parking.ParkCar("A1", this.car));
        }

        [Test]
        public void Test_Remove_Car_Invalid_Spot()
        {
            Assert
                .Throws<ArgumentException>(() => this.parking.RemoveCar("G4", this.car));
        }

        [Test]
        public void Test_Remove_Car_Invalid_Car()
        {
            Car newCar = new Car("Make1", "Number1");

            Assert
                .Throws<ArgumentException>(() => this.parking.RemoveCar("A1", newCar));
        }

        [Test]
        public void Test_Remove_Car()
        {
            this.parking.ParkCar("A1", this.car);

            Assert.AreEqual($"Remove car:{car.RegistrationNumber} successfully!",
                this.parking.RemoveCar("A1", this.car));
        }
    }
}