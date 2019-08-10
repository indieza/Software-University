namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car1;
        private Car car2;
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            this.car1 = new Car("Make1", "Number1");
            this.car2 = new Car("Make2", "Number2");
            this.softPark = new SoftPark();
        }

        [Test]
        public void Test_Constructure()
        {
            Assert.AreEqual("Make1", this.car1.Make);
            Assert.AreEqual("Number1", this.car1.RegistrationNumber);

            Assert.AreEqual(12, this.softPark.Parking.Count);
        }

        [Test]
        public void Test_Park_On_Not_Existing_Spot()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("Z3", this.car1));
        }

        [Test]
        public void Test_Park_On_Taken_Spot()
        {
            this.softPark.ParkCar("A1", this.car1);
            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("A1", this.car2));
        }

        [Test]
        public void Test_Park_Existing_Car()
        {
            this.softPark.ParkCar("A1", this.car1);
            Assert.Throws<InvalidOperationException>(() => this.softPark.ParkCar("A2", this.car1));
        }

        [Test]
        public void Test_Park_Car()
        {
            Assert.AreEqual($"Car:{this.car1.RegistrationNumber} parked successfully!", this.softPark.ParkCar("A1", this.car1));
        }

        [Test]
        public void Test_Remove_Car_On_Not_Existing_Spot()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("Z3", this.car1));
        }

        [Test]
        public void Test_Remove_Not_Existing_Car_On_Spot()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("A1", this.car1));
        }

        [Test]
        public void Test_Remove_Car()
        {
            this.softPark.ParkCar("A1", this.car1);

            Assert.AreEqual($"Remove car:{this.car1.RegistrationNumber} successfully!",
                this.softPark.RemoveCar("A1", this.car1));
        }
    }
}