using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Make", "Model", 10, 10);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual("Make", this.car.Make);
            Assert.AreEqual("Model", this.car.Model);
            Assert.AreEqual(10, this.car.FuelConsumption);
            Assert.AreEqual(10, this.car.FuelCapacity);
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        public void Test_Make()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "Model", 10, 10));
        }

        [Test]
        public void Test_Model()
        {
            Assert.Throws<ArgumentException>(() => new Car("Make", null, 10, 10));
        }

        [Test]
        public void Test_FuelConsumption()
        {
            Assert.Throws<ArgumentException>(() => new Car("Make", "Model", 0, 10));
        }

        [Test]
        public void Test_FuelCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Car("Make", "Model", 10, 0));
        }

        [Test]
        public void Test_Refuel_Exception()
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(0));
        }

        [Test]
        public void Test_Refuel()
        {
            this.car.Refuel(1);
            Assert.AreEqual(1, this.car.FuelAmount);
        }

        [Test]
        public void Test_Refuel_If_Statement()
        {
            this.car.Refuel(12);
            Assert.AreEqual(10, this.car.FuelAmount);
        }

        [Test]
        public void Test_Drive_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(1000));
        }

        [Test]
        public void Test_Drive()
        {
            this.car.Refuel(1);
            this.car.Drive(1);

            Assert.AreEqual(0.9, this.car.FuelAmount);
        }
    }
}